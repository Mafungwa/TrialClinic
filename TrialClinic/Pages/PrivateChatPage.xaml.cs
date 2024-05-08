using TrialClinic.Models;
using TrialClinic.Services;
using System.Collections.ObjectModel;


namespace TrialClinic.Pages;

public partial class PrivateChatPage : ContentPage
{

	private TrialLocalDatabase _database;
	private ObservableCollection<PrivateChat> _secretechats;

	public ObservableCollection<PrivateChat> SecreteChats
	{
		get { return _secretechats; }
		set
		{
			_secretechats = value;

			OnPropertyChanged(nameof(SecreteChats));
		}

	}

	public void OnSendButtonClicked(object sender, EventArgs e)
	{
		var messageChat = new PrivateChat
		{
			Message = MessageEntry.Text
		};

		SecreteChats.Add(messageChat);
        MessageEntry.Text = string.Empty;

		_database.SaveChatMessage(messageChat);
	}

    protected override void OnAppearing()
    {
		base.OnAppearing();
        SecreteChats = new ObservableCollection<PrivateChat>(_database.GetPrivateChat());
    }
    public PrivateChatPage()
	{
		InitializeComponent();

		BindingContext = this;
	}
}