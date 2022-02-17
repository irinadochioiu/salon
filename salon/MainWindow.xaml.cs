using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace salon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }
}
public partial class MainWindow : Window
    {
    ActionState action = ActionState.Nothing;
    SalonModel ctx = new SalonModel();
    CollectionViewSource clientVSource;
    private CollectionViewSource clinetVSource;

    public MainWindow()
        {
            InitializeComponent();
        DataContext = this;

    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        //using System.Data.Entity;
        clinetVSource =
       ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientViewSource")));
        clientVSource.Source = ctx.Clienti.Local;
        ctx.Clienti.Load();
    }
}



private void btnAdd_Click(object sender, RoutedEventArgs e)
{
    action = ActionState.New;
}
private void btnEditO_Click(object sender, RoutedEventArgs e)
{
    action = ActionState.Edit;
}
private void btnNext_Click(object sender, RoutedEventArgs e)
{
    object clientVSource = null;
    clientVSource.View.MoveCurrentToNext();
}
private void btnPrevious_Click(object sender, RoutedEventArgs e)
{
    customerVSource.View.MoveCurrentToPrevious();
}

private void SaveClienti()
{
    Client client = null;
    if (action == ActionState.New)
    {
        try
        {
            //instantiem Customer entity
            client = new Client()
            {
                FirstName = firstNameTextBox.Text.Trim(),
                LastName = lastNameTextBox.Text.Trim()
            };
            //adaugam entitatea nou creata in context
            ctx.Clienti.Add(client);
            clientVSource.View.Refresh();
            //salvam modificarile
            ctx.SaveChanges();
        }
        //using System.Data;
        catch (DataException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    else
   if (action == ActionState.Edit)
    {
        try
        {
            client = (Client)clientDataGrid.SelectedItem;
            client.FirstName = firstNameTextBox.Text.Trim();
            client.LastName = lastNameTextBox.Text.Trim();
            //salvam modificarile
            ctx.SaveChanges();
        }
        catch (DataException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    else if (action == ActionState.Delete)
    {
        try
        {
            client = (Client)customerDataGrid.SelectedItem;
            ctx.Clienti.Remove(c);
            ctx.SaveChanges();
        }
        catch (DataException ex)
        {
            MessageBox.Show(ex.Message);
        }
        clientVSource.View.Refresh();
    }

}


private void gbOperations_Click(object sender, RoutedEventArgs e)
{
    Button SelectedButton = (Button)e.OriginalSource;
    Panel panel = (Panel)SelectedButton.Parent;

    foreach (Button B in panel.Children.OfType<Button>())
    {
        if (B != SelectedButton)
            B.IsEnabled = false;
    }
    gbActions.IsEnabled = true;
}
private void ReInitialize()
{

    Panel panel = gbOperations.Content as Panel;
    foreach (Button B in panel.Children.OfType<Button>())
    {
        B.IsEnabled = true;
    }
    gbActions.IsEnabled = false;
}
private void btnCancel_Click(object sender, RoutedEventArgs e)
{
    ReInitialize();
}
private void btnSave_Click(object sender, RoutedEventArgs e)
{
    TabItem ti = tbCtrlproiect_maria.SelectedItem as TabItem;

    switch (ti.Header)
    {
        case "Clienti":
            SaveCustomers();
            break;
        case "Servicii":
            SaveInventory();
            break;
        case "Programari":
            break;
    }
    ReInitialize();
}

}
