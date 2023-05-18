using CommonLib.Implementations;
using CommonLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfInterfaces.Views
{
    /// <summary>
    /// Lógica de interacción para UscUser.xaml
    /// </summary>
    public partial class UscUser : UserControl
    {
        User user;
        UserImpl userImpl;
        byte op = 0;
        public UscUser()
        {
            InitializeComponent();
            BtnDisable();
        }
        void Clear()
        {
            txtName.Text = string.Empty;    
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            this.op = 1;
            Clear();
        }
        void BtnDisable()
        {
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }
        void BtnEnable()
        {
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.op = 2;
        }
        void Select()
        {
            userImpl = new UserImpl();
            dgUsers.ItemsSource = null;
            try
            {
                dgUsers.ItemsSource = userImpl.Select().DefaultView;
                dgUsers.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (user != null)
            {
                if (MessageBox.Show("¿Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    userImpl = new UserImpl();
                    try
                    {
                        int n = userImpl.Delete(user);
                        if (n > 0)
                        {
                            MessageBox.Show("Registro eliminado correctamente", "Eliminar", MessageBoxButton.OK, MessageBoxImage.Information);
                            Select();   
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el registro", "Eliminar", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            switch (op)
            {
                case 1:
                    user = new User();
                    user.Name = txtName.Text;
                    try
                    {
                        if (txtName.Text == "" )
                        {
                            MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            int n = userImpl.Insert(user);
                            if (n > 0)
                            {
                                MessageBox.Show("Registro insertado correctamente", "Insertar", MessageBoxButton.OK, MessageBoxImage.Information);
                                Select();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo insertar el registro", "Insertar", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case 2:
                    if (txtName.Text == "")
                    {
                        MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        user.Name = txtName.Text;
                        try
                        {
                            int n = userImpl.Update(user);
                            if (n > 0)
                            {
                                MessageBox.Show("Registro actualizo correctamente", "Actualizar", MessageBoxButton.OK, MessageBoxImage.Information);
                                Select();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo actualizar el registro", "Actualizar", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgUsers.SelectedItem != null && dgUsers.Items.Count > 0)
            {
                try
                {
                    DataRowView dataRow = (DataRowView)dgUsers.SelectedItem;
                    byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                    userImpl = new UserImpl();
                    user = userImpl.GetUser(id);
                    if (user != null)
                    {
                        txtName.Text = user.Name;
                        BtnEnable();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void dgUsers_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
        }
    }
}
