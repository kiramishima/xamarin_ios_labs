using System;
using Foundation;
using UIKit;

namespace AppLabMVC
{
    public partial class ViewController : UIViewController
    {
        Services srv;
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            srv = new Services();
            btnSearchProduct.TouchUpInside += OnSearchProduct;
            srv.ChangeStatus += Srv_ChangeStatus;
        }

        private void Srv_ChangeStatus(object sender, NorthWind.IChangeStatusEventArgs e)
        {
            activityIndicator.Hidden = true;
            lblStatusIndicator.Hidden = false;
            lblStatusIndicator.Text = e.Status.ToString();
            // activityIndicator
        }

        private async void OnSearchProduct(object sender, EventArgs e)
        {
            lblStatusIndicator.Hidden = true;
            activityIndicator.Hidden = false;
            var p = await srv.GetProductByIDAsync(int.Parse(txtProduct.Text));
            txtProductName.Text = p.ProductName;
            txtProductPrize.Text = p.UnitPrice.ToString();
            txtProductExistence.Text = p.UnitsInStock.ToString();
            txtProductCategory.Text = p.CategoryID.ToString();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);
            if(segue.DestinationViewController is ValidateController Controller)
            {
                Controller.Model = srv;
            }
        }
    }
}