namespace Notes;

public partial class NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public NotePage()
    {
        InitializeComponent();
        if (File.Exists(_fileName))
            TextEditor.Text = File.ReadAllText(_fileName);
    }


    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Save the file.
        File.WriteAllText(_fileName, TextEditor.Text);
        await DisplayAlert(nameof(NotePage),
            "arquivo criado com sucesso",
            "ok");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (!File.Exists(_fileName))
        {
            await DisplayAlert("Deletar arquivo",
                "deletou o arquivo",
                "beleza");
        }

            // Delete the file.
            if (File.Exists(_fileName))
            File.Delete(_fileName);
        TextEditor.Text = string.Empty;
    }
}