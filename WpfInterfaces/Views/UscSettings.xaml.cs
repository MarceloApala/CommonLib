using CommonLib.Implementations;
using CommonLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Lógica de interacción para UscSettings.xaml
    /// </summary>
    public partial class UscSettings : UserControl
    {
        Role role;
        RoleImpl roleImpl;
        byte op = 0;
        public UscSettings()
        {
            InitializeComponent();
        }
        void Select()
        {
            roleImpl = new RoleImpl();
            dgRoles.ItemsSource = null;
            try
            {
                dgRoles.ItemsSource = roleImpl.Select().DefaultView;
                dgRoles.Columns[0].Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            switch (op)
            {
                case 1:
                    role = new Role();
                    role.Name =txtName.Text;
                    role.Description =txtDescription.Text;
                    try
                    {
                        if (txtName.Text == "" || txtDescription.Text == "" )
                        {
                            MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            int n = roleImpl.Insert(role);
                            if (n > 0)
                            {
                                MessageBox.Show("Registro insertado correctamente", "Insertar", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    if (txtName.Text == "" || txtDescription.Text == "")
                    {
                        MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        role.Name=txtName.Text;
                        role.Description=txtDescription.Text;
                        try
                        {
                            int n = roleImpl.Update(role);
                            if (n > 0)
                            {
                                MessageBox.Show("Registro actualizo correctamente", "Actualizar", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            this.op = 1;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.op = 2;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (role != null)
            {
                if (MessageBox.Show("¿Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    roleImpl = new RoleImpl();
                    try
                    {
                        int n = roleImpl.Delete(role);
                        if (n > 0)
                        {
                            MessageBox.Show("Registro eliminado correctamente", "Eliminar", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void dgRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgRoles.SelectedItem != null && dgRoles.Items.Count > 0)
            {
                try
                {
                    DataRowView dataRow = (DataRowView)dgRoles.SelectedItem;
                    byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                    roleImpl = new RoleImpl();
                    role = roleImpl.GetRole(id);
                    if (role != null)
                    {
                        txtName.Text = role.Name;
                        txtDescription.Text = role.Description;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void dgRoles_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
        }
    }
}
