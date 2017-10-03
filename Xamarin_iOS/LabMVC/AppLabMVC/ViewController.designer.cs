// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AppLabMVC
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView activityIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSearchProduct { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnValidar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblStatusIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtProduct { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtProductCategory { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtProductExistence { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtProductName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtProductPrize { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (activityIndicator != null) {
                activityIndicator.Dispose ();
                activityIndicator = null;
            }

            if (btnSearchProduct != null) {
                btnSearchProduct.Dispose ();
                btnSearchProduct = null;
            }

            if (btnValidar != null) {
                btnValidar.Dispose ();
                btnValidar = null;
            }

            if (lblStatusIndicator != null) {
                lblStatusIndicator.Dispose ();
                lblStatusIndicator = null;
            }

            if (txtProduct != null) {
                txtProduct.Dispose ();
                txtProduct = null;
            }

            if (txtProductCategory != null) {
                txtProductCategory.Dispose ();
                txtProductCategory = null;
            }

            if (txtProductExistence != null) {
                txtProductExistence.Dispose ();
                txtProductExistence = null;
            }

            if (txtProductName != null) {
                txtProductName.Dispose ();
                txtProductName = null;
            }

            if (txtProductPrize != null) {
                txtProductPrize.Dispose ();
                txtProductPrize = null;
            }
        }
    }
}