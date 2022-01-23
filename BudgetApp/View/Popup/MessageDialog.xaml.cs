using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace BudgetApp.View.Popup
{
    public partial class MessageDialog : PopupPage
    {
        public MessageDialog(string title, string message, string okText, Action okAction = null, string cancelText = null, Action CancelAction = null)
        {
            InitializeComponent();
            Setup(title, message, okText, okAction, cancelText, CancelAction);
        }

        private void Setup(string title, string message, string okText, Action okAction, string cancelText, Action cancelAction)
        {
            CloseWhenBackgroundIsClicked = false;
            TitleTxt.Text = title;
            MessageTxt.Text = message;

            OkBtn.Text = okText;
            CancelBtn.IsVisible = !string.IsNullOrWhiteSpace(cancelText) ? true : false;
            CancelBtn.Text = cancelText;

            OkBtn.Clicked += async (s, e) =>
            {
                await Navigation.PopPopupAsync().ConfigureAwait(false);
                okAction?.Invoke();
            };

            CancelBtn.Clicked += async (s, e) =>
            {
                await Navigation.PopPopupAsync().ConfigureAwait(false);
                cancelAction?.Invoke();
            };
        }

        public static void Show(string title, string message, string OkText, Action OkAction = null)
        {
            MessageDialog md = new MessageDialog(title, message, OkText, OkAction);
            App.Current.MainPage.Navigation.PushPopupAsync(md);
        }

        public static void Show(string title, string message, string OkText, Action OkAction, string CancelText, Action CancelAction)
        {
            MessageDialog md = new MessageDialog(title, message, OkText, OkAction, CancelText, CancelAction);
            App.Current.MainPage.Navigation.PushPopupAsync(md);
        }
    }
}
