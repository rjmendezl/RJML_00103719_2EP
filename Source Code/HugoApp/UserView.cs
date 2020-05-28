using System;
using System.Windows.Forms;

namespace HugoApp
{
    public partial class UserView : Form
    {
        public UserView(int usuario)
        {
            int idUsuario = usuario;
            InitializeComponent();
        }
    }
}