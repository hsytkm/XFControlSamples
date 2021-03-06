﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFControlSamples.Views.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupPage : ContentPage
    {
        public PopupPage()
        {
            InitializeComponent();

            BindingContext = new PopupPageViewModel();
        }
    }

    class PopupPageViewModel
    {
        private static Page MainPage => Application.Current.MainPage;

        private const string _questionMessage = "What is your favorite dish?";
        private readonly static string[] _dishList = new[] { "Curry", "Pizza", "Sushi", "Ramen" };
        private static string GetAnswerMessage(string choice) =>
            (choice is null) ? "Push Esc Key? or Tap outside area?" : $"Your answer is {choice}.";

        public ICommand OkCommand => new Command<string>(async (msg) =>
            await MainPage.DisplayAlert("Title", msg, "OK"));

        public ICommand YesNoCommand => new Command<string>(async (title) =>
        {
            bool answer = await MainPage.DisplayAlert(title, "Do you like sushi?", "Yes", "No");
            var msg = answer ? "You are a good!!!" : "You are a bad.";
            await MainPage.DisplayAlert("Answer", msg, "OK");
        });

        public ICommand SomeChoicesCommand1 => new Command<string>(async (param) =>
        {
            string choice = await MainPage.DisplayActionSheet(
                _questionMessage, null, null, _dishList);

            var msg = GetAnswerMessage(choice);
            await MainPage.DisplayAlert("Answer", msg, "OK");
        });

        public ICommand SomeChoicesCommand2 => new Command<string>(async (param) =>
        {
            string choice = await MainPage.DisplayActionSheet(
                _questionMessage, "Cancel", null, _dishList);

            var msg = GetAnswerMessage(choice);
            await MainPage.DisplayAlert("Answer", msg, "OK");
        });

        public ICommand SomeChoicesCommand3 => new Command<string>(async (param) =>
        {
            string choice = await MainPage.DisplayActionSheet(
                _questionMessage, "Cancel", "Destruction", _dishList);

            var msg = GetAnswerMessage(choice);
            await MainPage.DisplayAlert("Answer", msg, "OK");
        });

        public ICommand PromptCommand => new Command(async () =>
        {
            // The DisplayPromptAsync method is currently only implemented on iOS and Android. 2020/3/4
            string answer = await MainPage.DisplayPromptAsync(
                "Question1",
                "What's your phone number?",
                maxLength: 10,
                keyboard: Keyboard.Telephone,
                initialValue:"012345");

            await MainPage.DisplayAlert("Answer", $"Your phone number is {answer}.", "OK");
        });

    }
}