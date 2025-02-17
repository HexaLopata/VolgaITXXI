﻿using System;
using VolgaIT.Views;
using System.Windows.Forms;

namespace VolgaIT
{
    public partial class WaitingForm : Form, IWaitingView
    {
        public event Action AnalysisAgainButtonClicked;
        public event Action OpenFileButtonClicked;

        private readonly string _waitingMessage = "Обработка файла в процессе завершения. Когда она будет завершена, результат запишется в указанный вами файл";
        private readonly string _analysisEndedMessage = "Текст был успешно проанализирован, вы можете увидеть результат в созданном файле";

        public WaitingForm()
        {
            InitializeComponent();
            
            InfoLabel.Text = _waitingMessage;
            AnalysisAgainButton.Hide();
            OpenFileButton.Hide();
        }

        public void OnAnalysisEnded()
        {
            AnalysisAgainButton.Show();
            OpenFileButton.Show();
            InfoLabel.Text = _analysisEndedMessage;
        }

        private void AnalysisAgainButton_Click(object sender, EventArgs e)
        {
            AnalysisAgainButtonClicked?.Invoke();
        }

        void IView.Close()
        {
            FormsManager.Instance.Close(this);
        }

        void IView.Show()
        {
            FormsManager.Instance.Show(this);
        }

        void IView.ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileButtonClicked?.Invoke();
        }
    }
}
