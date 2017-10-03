using System;

using UIKit;

namespace Lab01
{
    public partial class ValidateViewController : UIViewController
    {
        public ValidateViewController(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            btnValidar.TouchUpInside += (object sender, EventArgs e) =>
            {
                Validate();
            };
        }

        async void Validate()
        {
            var Client = new SALLab06.ServiceClient();
            var Result = await Client.ValidateAsync(txtEmail.Text, txtPassword.Text, this);

            var Alert = UIAlertController.Create("Resultado",
                $"{Result.Status}\n{Result.FullName}\n{Result.Token}",
                UIAlertControllerStyle.Alert);
            Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            PresentViewController(Alert, true, null);
        }
    }
}