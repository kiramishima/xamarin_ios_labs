using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Lab01
{
    public partial class ViewController : UIViewController
    {
        string TranslatedNumber = string.Empty;
        List<string> PhoneNumbers = new List<string>();
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            // var TranslatedNumber = string.Empty;

            TranslateButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                var Translator = new PhoneTranslator();
                TranslatedNumber = Translator.ToNumber(PhoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(TranslatedNumber))
                {
                    // No hay número a llamar
                    CallButton.SetTitle("Llamar", UIControlState.Normal);
                    CallButton.Enabled = false;
                }
                else
                {
                    // Hay un posible número telefónico a llamar
                    CallButton.SetTitle($"Llamar al {TranslatedNumber}", UIControlState.Normal);
                    CallButton.Enabled = true;
                }
            };
            CallButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                PhoneNumbers.Add(TranslatedNumber);
                var URL = new Foundation.NSUrl($"tel:{TranslatedNumber}");
                // Utilizar el manejador de URL con el prefijo tel: para invocar a la
                // aplicacionPhone de Apple, de lo contrario mostrar un dialogo de alerta
                if(!UIApplication.SharedApplication.OpenUrl(URL))
                {
                    var Alert = UIAlertController.Create("No soportado", "El esquema 'tel:' no es soportado en este dispositivo",
                        UIAlertControllerStyle.Alert);
                    Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                    PresentViewController(Alert, true, null);
                }
            };

            btnValidateView.TouchUpInside += (object sender, EventArgs e) =>
            {
                // Puede instaciarse el controlador con ID "CallHistoryController
                // establecido en el diseño
                if (Storyboard.InstantiateViewController("ValidateViewController") is
                    ValidateViewController Controller)
                {
                    // Coloca al Controlador en la pila de navegación
                    NavigationController.PushViewController(Controller, true);
                }
            };

            CallHistoryButton.TouchUpInside += (object sender, EventArgs e) =>
            {
                // Puede instaciarse el controlador con ID "CallHistoryController
                // establecido en el diseño
                if (Storyboard.InstantiateViewController("CallHistoryController") is
                    CallHistoryController Controller)
                {
                    // Proporciona la lista de número telefónicos a CallHistoryController
                    Controller.PhoneNumbers = PhoneNumbers;
                    // Coloca al Controlador en la pila de navegación
                    NavigationController.PushViewController(Controller, true);
                }
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        //async void Validate()
        //{
        //    var Client = new SALLab05.ServiceClient();
        //    var Result = await Client.ValidateAsync("email", "password", this);

        //    var Alert = UIAlertController.Create("Resultado", 
        //        $"{Result.Status}\n{Result.FullName}\n{Result.Token}",
        //        UIAlertControllerStyle.Alert);
        //    Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

        //    PresentViewController(Alert, true, null);
        //}

        //public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        //{
        //    base.PrepareForSegue(segue, sender);
        //    // Se desea realizar la transicion a CallHistoryController
        //    if ((object)segue.DestinationViewController is CallHistoryController Controller)
        //    {
        //        Controller.PhoneNumbers = PhoneNumbers;
        //    }
        //}
    }
}