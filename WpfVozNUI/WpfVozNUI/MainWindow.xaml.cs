using System;
using System.Globalization;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows;

namespace WpfVozNUI
{
    public partial class MainWindow : Window
    {
        // Motor (Texto a Voz)
        private readonly SpeechSynthesizer _synth = new SpeechSynthesizer();

        // Motor de reconocimiento de voz
        private SpeechRecognitionEngine _recognizer;

        // Estado para saber si esta escuchando
        private bool _isListening = false;

        public MainWindow()
        {
            InitializeComponent();

            // Configuracion inicial del sintetizador
            ConfigureTts();

            // Intentamos configurar el reconocimiento al iniciar
            // (si falla, la app sigue funcionando para TTS)
            TryConfigureAsr();

            AppendOutput("Aplicación iniciada. Puedes escribir texto y pulsar 'Leer (TTS)'.");
        }

        // -------------------------
        // 1) SÍNTESIS DE VOZ (TTS)
        // -------------------------
        private void ConfigureTts()
        {
            // Ajustes basicos
            _synth.Rate = 0;     // -10 a 10 (velocidad de habla)
            _synth.Volume = 100; // 0 a 100
        }

        private void SpeakButton_Click(object sender, RoutedEventArgs e)
        {
            string text = InputTextBox.Text?.Trim();

            if (string.IsNullOrWhiteSpace(text))
            {
                AppendOutput("No hay texto para leer.");
                return;
            }

            AppendOutput($"TTS -> {text}");

            // speakAsync evita bloquear la UI
            _synth.SpeakAsyncCancelAll();
            _synth.SpeakAsync(text);
        }

        // -------------------------
        // 2) RECONOCIMIENTO (ASR)
        // -------------------------
        private void TryConfigureAsr()
        {
            try
            {
                // debemos tener instalado el paquete de reconocimiento para el idioma que queramos usar
                var culture = new CultureInfo("es-ES");

                _recognizer = new SpeechRecognitionEngine(culture);

                // en escritorio suele ser el dispositivo de audio por defecto.
                _recognizer.SetInputToDefaultAudioDevice();

                // comandos concretos (mejor para demo y precisión)
                Choices commands = new Choices(
                    "saludar",
                    "adiós",
                    "limpiar",     // limpia el panel de salida
                    "leer texto"   // lee el contenido del TextBox por voz
                );

                GrammarBuilder gb = new GrammarBuilder(commands)
                {
                    Culture = culture
                };

                Grammar grammar = new Grammar(gb);
                _recognizer.LoadGrammar(grammar);

                // Eventos del reconocedor
                _recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
                _recognizer.SpeechRecognitionRejected += Recognizer_SpeechRecognitionRejected;

                StatusTextBlock.Text = "Estado: reconocimiento configurado (pulsa 'Iniciar voz')";
            }
            catch (Exception ex)
            {
                // Si falla, lo notificamos y seguimos (al menos TTS funcionará)
                StatusTextBlock.Text = "Estado: reconocimiento NO disponible (revisa idioma/entrada de micrófono)";
                AppendOutput("No se pudo configurar el reconocimiento de voz.");
                AppendOutput($"Detalle: {ex.Message}");
            }
        }

        private void StartVoiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (_recognizer == null)
            {
                AppendOutput("Reconocimiento no configurado. Revisa dependencias/idioma.");
                return;
            }

            if (_isListening)
            {
                AppendOutput("Ya estaba escuchando.");
                return;
            }

            try
            {
                // RecognizeMode.Multiple = se queda escuchando continuamente, asi aprovechamos el mismo reconocedor para varios comandos sin tener que reiniciarlo cada vez.
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
                _isListening = true;

                StatusTextBlock.Text = "Estado: escuchando comandos...";
                AppendOutput("ASR: escuchando (di: saludar / adiós / limpiar / leer texto).");
            }
            catch (InvalidOperationException)
            {
                // Puede ocurrir si ya estaba en RecognizeAsync
                AppendOutput("ASR: ya estaba en ejecución.");
            }
        }

        private void StopVoiceButton_Click(object sender, RoutedEventArgs e)
        {
            if (_recognizer == null) return;

            if (!_isListening)
            {
                AppendOutput("No estaba escuchando.");
                return;
            }

            try
            {
                _recognizer.RecognizeAsyncCancel();
                _recognizer.RecognizeAsyncStop();
            }
            catch { /* evitamos que un error menor rompa */ }

            _isListening = false;
            StatusTextBlock.Text = "Estado: voz detenida";
            AppendOutput("ASR: detenido.");
        }

        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // Confianza: cuanto más alto, más probable que sea correcto.
            // Si es demasiado baja, ignoramos para evitar falsos positivos.
            if (e.Result.Confidence < 0.60)
            {
                AppendOutput($"ASR (baja confianza {e.Result.Confidence:0.00}) -> {e.Result.Text}");
                return;
            }

            string command = e.Result.Text?.Trim().ToLowerInvariant();
            AppendOutput($"ASR (conf {e.Result.Confidence:0.00}) -> Comando: {command}");

            // Asociamos la voz a acciones de UI (NUI: Natural User Interface)
            switch (command)
            {
                case "saludar":
                    OutputTextBlock.Text += "\nAcción: ¡Hola! Encantado de verte.";
                    _synth.SpeakAsyncCancelAll();
                    _synth.SpeakAsync("Hola. ¿En qué puedo ayudarte?");
                    break;

                case "adiós":
                    OutputTextBlock.Text += "\nAcción: ¡Hasta luego!";
                    _synth.SpeakAsyncCancelAll();
                    _synth.SpeakAsync("Adiós. Hasta luego.");
                    break;

                case "limpiar":
                    OutputTextBlock.Text = "";
                    AppendOutput("Salida limpiada por comando de voz.");
                    break;

                case "leer texto":
                    // Reutilizamos la misma acción que el botón
                    Dispatcher.Invoke(() => SpeakButton_Click(this, new RoutedEventArgs()));
                    break;
            }
        }

        private void Recognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            AppendOutput("ASR: no se reconoció ningún comando válido.");
        }

        // -------------------------
        // UTILIDAD: salida en UI
        // -------------------------
        private void AppendOutput(string message)
        {
            // Añadimos timestamp para depurar mejor
            string line = $"[{DateTime.Now:HH:mm:ss}] {message}";

            // TextBlock no tiene AppendText como TextBox, así que concatenamos
            if (string.IsNullOrWhiteSpace(OutputTextBlock.Text))
                OutputTextBlock.Text = line;
            else
                OutputTextBlock.Text += "\n" + line;
        }

        protected override void OnClosed(EventArgs e)
        {
            // Liberar recursos correctamente
            try
            {
                _synth?.SpeakAsyncCancelAll();
                _synth?.Dispose();

                if (_recognizer != null)
                {
                    try { _recognizer.RecognizeAsyncCancel(); } catch { }
                    try { _recognizer.RecognizeAsyncStop(); } catch { }
                    _recognizer.Dispose();
                }
            }
            catch { /* evitar errores al cerrar */ }

            base.OnClosed(e);
        }
    }
}