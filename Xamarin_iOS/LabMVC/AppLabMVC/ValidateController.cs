using NorthWind;
using System;

using UIKit;

namespace AppLabMVC
{
    public partial class ValidateController : UIViewController
    {
        public INorthWindModel Model { get; set; }
        public ValidateController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        private void btnValidate_onClick(object sender, EventArgs e)
        {
            Validate();
        }

        async void Validate ()
        {
            var Client = new SALLab07.ServiceClient();
            var Result = await Client.ValidateAsync(txtEmail.Text, txtPassword.Text, Model);
            
            var Alert = UIAlertController.Create("Resultado",
                $"{Result.Status}\n{Result.FullName}\n{Result.Token}",
                UIAlertControllerStyle.Alert);
            Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            PresentViewController(Alert, true, null);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.

            btnValidate.TouchUpInside += btnValidate_onClick;
        }
    }
}