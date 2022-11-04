using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessLibrary
{
    public partial class LeftPanel : UserControl
    {
        public Board ParentBoard { get; set; }
        public LeftPanel(Board board)
        {
            InitializeComponent();
            ParentBoard = board;
            this.Width = ParentBoard.Width / 2;
            this.Height = ParentBoard.Height;
            this.Top = ParentBoard.Top;
            this.Left = ParentBoard.Left - this.Width;
        }
    }
}
