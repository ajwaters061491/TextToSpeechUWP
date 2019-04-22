using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.Media.SpeechSynthesis; //to read


namespace TextToSpeechUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SpeechSynthesizer speechSynthesizer;

        public MainPage()
        {
            this.InitializeComponent();
            speechSynthesizer = new SpeechSynthesizer();
        }

        private void BtnButton_Click(object sender, RoutedEventArgs e)
        {
            Talk(txtTextToSpeech.Text); //this is the text box's location
        }

        private async void Talk(string message) //method to read the message passed in
        {
            var stream = await speechSynthesizer.SynthesizeTextToStreamAsync(message);
            media.SetSource(stream, stream.ContentType);
            media.Play();
        }
    }
}
