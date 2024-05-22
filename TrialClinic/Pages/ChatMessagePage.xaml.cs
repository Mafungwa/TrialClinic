using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using TrialClinic.Models;
using TrialClinic.Pages;
using TrialClinic.Services;

namespace TrialClinic.Pages;


public partial class ChatMessagePage : ContentPage
{
    private TrialLocalDatabase _database;
    private int _currentTrialId;    
    private ChatMessage _message;

    public ObservableCollection<ChatMessage> Messages { get; set; }

    public ChatMessagePage()
    {

        InitializeComponent();

        _database = new TrialLocalDatabase();
        // _currentTrialId = trialId;

        _currentTrialId = 0;


        Messages = new ObservableCollection<ChatMessage>(_database.GetMessagesByForum(_currentTrialId));
        BindingContext = this;
    }

    public ChatMessage GetMessage()
    {
        return _message;
    }

    public async void OnSendButtonClicked(object sender, EventArgs e, ChatMessage message)
    {
       var _message = new ChatMessage
       {
            ForumId = _currentTrialId,
            UserId = _currentTrialId,
            MessageContent = MessageEntry.Text,
            DateTime = DateTime.Now
        };

        Messages.Add(message);
        MessageEntry.Text = string.Empty;
        _database.SaveChatMessage(message);
    }

    private void OnNewThreadClicked(object sender, EventArgs e)
    {

    }

    private void OnNewThreadClicked1(object sender, EventArgs e)
    {

    }
}

public class Thread
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }
    public ObservableCollection<Reply> Replies { get; set; }
}

public class Reply
{
    public string Author { get; set; }
    public string Content { get; set; }
}

