using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form1 : Form
    {

        Label[,] lab = new Label[40, 40];                   //宣告一個二維陣列Labels
        Button[,] buttons = new Button[40, 40];             //宣告一個二維陣列Buttons
        int[] randomize = new int[500];                        //宣告一個一維陣列(存取亂數)
        Random rnd = new Random(Guid.NewGuid().GetHashCode());  //宣告產生亂數
        int[,] mines;                                           //宣告一個二維陣列 mines
        int col, row, mines_count;                              //宣告全域變數 《col row mines_count》→不能更動
        int timer_cnt = 0;                                      //宣告遊戲計時 timer_cnt
        int mines_temp;                                         //
        int size=30;                                            //宣告把Labels、Buttons 大小
        Panel[] pan = new Panel[100];                           //宣告把panel當作drawline
        
        public Form1()
        {
            InitializeComponent();  
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lblView.Font = new Font("Andale Mono", 8, FontStyle.Bold);
            lblView.ForeColor = Color.MediumBlue;
            lbl_mines.Font = new Font("Andale Mono", 8, FontStyle.Bold);
            lbl_mines.ForeColor = Color.MediumBlue;
        }
        public void create_label(int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    lab[i, j] = new Label();
                    lab[i, j].Size = new Size(size, size);
                    lab[i, j].Name = i.ToString() + " " + j.ToString();     //紀錄lab[i, j]位置
                    lab[i, j].Location = new Point(size * j+5, size * i+ size);     // X 座標，Y 座標
                    //lab[i, j].Text = Convert.ToString((i)+(j*col));
                    lab[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    lab[i, j].Click += new EventHandler(label_click);
                    this.Controls.Add(lab[i, j]);
                }
            }
        }
        public void create_buttons(int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Name = i.ToString() + " " + j.ToString();     //紀錄buttons[i, j]位置
                    buttons[i, j].Size = new Size(size, size);
                    buttons[i, j].Location = new Point(size * j+5, size * i+ size);
                    buttons[i, j].MouseDown += new MouseEventHandler(buttons_click);
                    buttons[i, j].BackColor = Color.Wheat;
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }
        /*Label_Click------------------------------------------------------------------------*/
        protected void label_click(object sender,EventArgs e)
        {
            if (tmrCounter.Enabled == false) return; //時間暫停，遊戲結束
            //win_game();
            //MessageBox.Show("lal_click");
            Label lbl = sender as Label;
            /*btn_name轉成數字，帶入col、row*/
            String str = lbl.Name;
            string[] split = str.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            
            if (check_buttons_flag(i,j) == true)
            {
                if (mines[i, j] != 0)
                {
                   // MessageBox.Show(mines[i,j].ToString());
                    delete_blank_from_label(i, j);
                }
                win_game();
            }
            else
            {
                return;
            }
            
        }
        public void delete_blank_from_label(int x, int y)
        {
            bool bomb = false;
            if (x-1 >= 0 && y >= 0 && x -1< row && y < col)
            {
                if(buttons[x-1, y ].Text != "X") buttons[x - 1, y].Visible = false;
                if (mines[x - 1, y] == -1&& buttons[x - 1, y].Visible == false) bomb = true;
                if (mines[x - 1, y] == 0)
                {
                    buttons[x - 1, y].Visible = true;
                    delete_blank(x-1, y);
                } 
            }
            if (x-1 >= 0 && y+1 >= 0 && x -1< row && y +1< col)
            {
                if (buttons[x - 1, y+1].Text != "X") buttons[x - 1, y + 1].Visible = false;
                if(mines[x - 1, y+1] == -1 && buttons[x - 1, y + 1].Visible == false) bomb = true;
                if (mines[x - 1, y + 1] == 0)
                {
                    buttons[x - 1, y + 1].Visible = true;
                    delete_blank(x - 1, y + 1);
                }
            }
            if (x-1 >= 0 && y-1 >= 0 && x-1 < row && y-1 < col)
            {
                if (buttons[x - 1, y-1].Text != "X") buttons[x - 1, y - 1].Visible = false;
                if (mines[x - 1, y - 1] == -1&& buttons[x - 1, y - 1].Visible == false) bomb = true;
                if (mines[x - 1, y - 1] == 0)
                {
                    buttons[x - 1, y - 1].Visible = true;
                    delete_blank(x - 1, y-1);
                }
               
            }
            if (x >= 0 && y +1>= 0 && x < row && y +1< col)
            {
                if (buttons[x , y+1].Text != "X") buttons[x, y + 1].Visible = false;
                if (mines[x , y + 1] == -1&& buttons[x, y + 1].Visible == false) bomb = true;
                if (mines[x, y + 1] == 0)
                {
                    buttons[x, y + 1].Visible = true;
                    delete_blank(x, y + 1);
                }
            }
            if (x >= 0 && y -1>= 0 && x < row && y-1 < col)
            {
                if (buttons[x , y-1].Text != "X") buttons[x, y - 1].Visible = false;
                if (mines[x, y - 1] == -1&& buttons[x, y - 1].Visible ==false) bomb = true;
                if (mines[x, y - 1] == 0)
                {
                    buttons[x, y - 1].Visible = true;
                    delete_blank(x, y - 1);
                }
            }
            if (x+1 >= 0 && y >= 0 && x+1 < row && y < col)
            {
                if (buttons[x + 1, y].Text != "X") buttons[x + 1, y].Visible = false;
                if (mines[x+1, y ] == -1&& buttons[x + 1, y].Visible == false) bomb = true;
                if (mines[x + 1, y] == 0)
                {
                    buttons[x + 1, y].Visible = true;
                    delete_blank(x+1, y);
                }
                
            }
            if (x+1 >= 0 && y +1>= 0 && x+1 < row && y+1 < col)
            {
                if (buttons[x + 1, y+1].Text != "X") buttons[x + 1, y + 1].Visible = false;
                if (mines[x + 1, y+1] == -1&& buttons[x + 1, y + 1].Visible == false) bomb = true;
                if (mines[x + 1, y + 1] == 0)
                {
                    buttons[x + 1, y + 1].Visible = true;
                    delete_blank(x+1, y + 1);
                }
               
            }
            if (x+1 >= 0 && y-1 >= 0 && x+1 < row && y-1 < col)
            {
                if (buttons[x + 1, y-1].Text != "X") buttons[x+1, y-1].Visible = false;
                if (mines[x + 1, y-1] == -1&& buttons[x + 1, y - 1].Visible == false) bomb = true;
                if (mines[x + 1, y - 1] == 0)
                {
                    buttons[x + 1, y - 1].Visible = true;
                    delete_blank(x+1, y - 1);
                }
                
            }
            if (bomb)//Game Over 標錯XX，錯誤地雷 
            {
                lose_game();
            }
        }
        /*標記XX判斷----------------------------------------------------------------------------------*/
        public bool  check_buttons_flag(int i,int j)
        {
            int cnt = 0;
            if( i >= 0 && j + 1 >= 0 && i < row && j + 1 < col)
            {
                if (buttons[i , j + 1].Text == "X") cnt++;
            }
            if(i >= 0 && j - 1 >= 0 && i < row && j - 1 < col)
            {
                if (buttons[i , j - 1].Text == "X" ) cnt++;
            }
            if(i + 1 >= 0 && j >= 0 && i + 1 < row && j < col)
            {
                if (buttons[i + 1, j].Text == "X") cnt++;
            }
            if (i + 1 >= 0 && j - 1 >= 0 && i + 1 < row && j - 1 < col)
            {
                if (buttons[i + 1, j - 1].Text == "X")cnt++;
            }
            if (i + 1 >= 0 && j + 1 >= 0 && i + 1 < row && j + 1 < col)
            {
                if (buttons[i + 1, j + 1].Text == "X") cnt++;
            }
            if (i - 1 >= 0 && j >= 0 && i - 1 < row && j < col)
            {
                if (buttons[i - 1, j].Text == "X") cnt++;
            }
            if (i - 1 >= 0 && j - 1 >= 0 && i - 1 < row && j - 1 < col)
            {
                if (buttons[i - 1, j - 1].Text == "X") cnt++;
            }
            if (i - 1 >= 0 && j + 1 >= 0 && i - 1 < row && j + 1 < col)
            {
                if (buttons[i - 1, j + 1].Text == "X") cnt++;
            }
            return cnt == mines[i, j] ? true : false;
        }
        /*Buttons_Click----------------------------------------------------------------------*/
        protected void buttons_click(object sender, MouseEventArgs e)
        {
            
            if (tmrCounter.Enabled == false) return; //時間暫停，遊戲結束

            Button btn = sender as Button;
    
            /*btn_name轉成數字，帶入col、row*/
            String str = btn.Name;
            string[] split = str.Split(' ');
            int i = Convert.ToInt32(split[0]);
            int j = Convert.ToInt32(split[1]);
            /* btn.text== X And 案左鍵 return*/
            if (buttons[i, j].Text == "X" && e.Button != MouseButtons.Right) return;
            /*按滑鼠右鍵--------------------------------------------------------------------------------*/
            if (e.Button == MouseButtons.Right)
            {
                // MessageBox.Show("right");
                
                if (buttons[i, j].Text != "X")
                {
                    buttons[i, j].Text = "X";
                    buttons[i, j].Font = new Font("Andale Mono", 12, FontStyle.Bold);
                    buttons[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    buttons[i, j].ForeColor = Color.Crimson;
                    mines_amount(--mines_temp);
                }
                else
                {
                    buttons[i, j].Text = "";
                    mines_amount(++mines_temp);
                }
            }
            /*按滑鼠左鍵--------------------------------------------------------------------------------*/
            else
            {
                if (mines[i, j] == -1)  //Game Over
                {
                    lose_game();
                }
                
                delete_blank(i, j);
                btn.Visible = false;
            }
            win_game();
        }
        /*遊戲過關，地雷全部引爆-------------------------------------------------------------------------*/
        public void win_game()
        {
            int tmp = check_buttons_num();
            //this.Text = mines_count.ToString()+"  "+tmp.ToString();
            if (mines_count==tmp)
            {
                MessageBox.Show(this, "Congratulations!", "恭喜過關"); //恭喜過關
                tmrCounter.Enabled = false;
            }
        }
        /*檢查剩餘Buttons數量----------------------------------------------------------------------------*/
        public int check_buttons_num()
        {
            int num = 0;
            for (int a = 0; a < row; a++)
            {
                for (int b = 0; b < col; b++)
                {
                    if (buttons[a, b].Visible==true)
                    {
                        ++num;
                        
                    }
                }
            }
            return num;
        }
        /*遊戲結束，地雷全部引爆-------------------------------------------------------------------------*/
        public void lose_game()
        {
            tmrCounter.Enabled = false;
            for (int a = 0; a < row; a++)
            {
                for (int b = 0; b < col; b++)
                {
                    if (mines[a, b] == -1)
                    {
                        if (buttons[a, b].Text == "X")
                        {
                            lab[a, b].ForeColor = Color.Crimson;
                        }
                        buttons[a, b].Visible = false;
                    }
                }
            }
            MessageBox.Show(this, "Game Over!", "遊戲結束"); //Game Over
        }
        private void 初級ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start_game(1);
        }

        private void 中級ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start_game(2);
        }

        private void 高級ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            start_game(3);
            
        }
        /*地雷數量-------------------------------------------------------------------------------*/
        public void mines_amount(int n)
        {
            lbl_mines.Text = n.ToString();
        }
        public void start_game_timer()
        {
            timer_cnt = 0;
            tmrCounter.Enabled = true;
        }
        /*清除遊戲上的方格和數字、地雷----------------------------------------------------------*/
        public void reset_game()
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;//固定視窗大小
            for (int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    Controls.Remove(buttons[i, j]);
                    Controls.Remove(lab[i, j]);

                }
            }
            for (int i = 0; i <= col; i++)
            {
                Controls.Remove(pan[i]);
            }
            for (int j = col; j < col + row + 1; j++)
            {
                Controls.Remove(pan[j]);
            }
       }
        /*時間----------------------------------------------------------------------------------*/
        private void tmrCounter_Tick(object sender, EventArgs e)
        {
            timer_cnt++;
            lblView.Text = timer_cnt.ToString();
        }

        public void delete_blank(int x, int y)
        {

            
            //Flood Fill Algorithm  模擬小畫家倒墨水  zerojudge.tw → d626. 小畫家真好用
            if (x >= 0 && y >= 0 && x < row && y < col)
            {
                if (buttons[x, y].Visible == false ) return;         //判斷若為btn.visible==false回傳，
                if (buttons[x, y].Text == "X" ) return;              //判斷若為btn.text=="X"回傳 ，不能被消除        
                buttons[x, y].Visible = false;
                if (mines[x, y] == 0 )
                {
                    
                    delete_blank(x + 1, y);
                    delete_blank(x + 1, y + 1);
                    delete_blank(x + 1, y - 1);

                    delete_blank(x - 1, y);
                    delete_blank(x - 1, y-1);
                    delete_blank(x - 1, y+1);

                    delete_blank(x, y + 1);
                    delete_blank(x, y - 1);
                   
                }
            }
            return;
            
        }
        /*-----------------------------------------------------------------------------------*/
        public void create_mines(int mine_count, int row, int col)
        {
            mines_temp = mines_count;
            mines = new int[row, col];
            int cnt = mine_count;               //地雷的數量
            /*二微陣列mines，全部設定為0 ---------------------------------------------------*/
            /*for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    mines[i, j] = 0;
                }
            }*/
            /*亂數產生地雷 mines[row,coll] ------------------------------------------------*/
            while (cnt > 0)
            {
                int mine_row = rnd.Next(row);
                int mine_col = rnd.Next(col);
                if (mines[mine_row, mine_col] == 0)
                {
                    lab[mine_row, mine_col].Text = "☻";
                    lab[mine_row, mine_col].Font = new Font("Andale Mono", 22, FontStyle.Bold);
                    lab[mine_row, mine_col].TextAlign= ContentAlignment.MiddleCenter;
                    mines[mine_row, mine_col] = -1;     //mines[row,col]=-1 為地雷
                    cnt--;
                }
            }
            /*----------------------------------------------------------------------------*/
            /*------------------------------逆向思考，地雷向周圍填數字--------------------*/
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mines[i, j] != -1)
                    {
                        int mines_cnt = 0;
                        for (int a = -1; a < 2; a++)
                        {
                            for (int b = -1; b < 2; b++)
                            {
                                if (i + a >= 0 && j + b >= 0 && i + a < row && j + b < col)  //檢查範圍 
                                {
                                    if (mines[i + a, j + b] == -1)
                                    {
                                        mines_cnt++;
                                    }
                                }
                            }
                        }
                        mines[i, j] = mines_cnt;

                        if (mines_cnt == 0)
                        {
                            lab[i, j].Text = " ";
                        }
                        else
                        {
                            lab[i, j].Text = mines_cnt.ToString();
                            lab[i, j].Font = new Font("Andale Mono", 18 , FontStyle.Bold);
                            switch (mines_cnt)
                            {

                                case 1:
                                    lab[i, j].ForeColor = Color.Blue;
                                    break;
                                case 2:
                                    lab[i, j].ForeColor = Color.Green;
                                    break;
                                case 3:
                                    lab[i, j].ForeColor = Color.Red;
                                    break;
                                case 4:
                                    lab[i, j].ForeColor = Color.DarkBlue;//深藍
                                    break;
                                case 5:
                                    lab[i, j].ForeColor = Color.Maroon;//深紅
                                    break;
                                default:
                                    lab[i, j].ForeColor = Color.SkyBlue;//天空藍
                                    break;
                            }
                        }
                    }

                }
            }
            /*----------------------------------------------------------------------------*/
        }
        /*遊戲開始,設定行、列、地雷數目---------------------------------------------------*/
        public void start_game(int n)
        {
            reset_game();
            this.BackColor = Color.Snow; //form1.backcolor

            switch (n)
            {
                case 1:
                    col = 9;
                    row = 9;
                    mines_count = 10;
                    this.Width = size*col+size;   //300
                    this.Height = this.Width + 12 + size;//342

                    break;
                case 2:
                    col = 16;
                    row = 16;
                    mines_count = 40;
                    this.Width = size * col + size;//510
                    this.Height = this.Width + 12 + size;//552

                    break;
                case 3:
                    col = 30;
                    row = 16;
                    mines_count = 99;
                    this.Width = size * col + size;   //930
                    this.Height = size * row + size + 12 + size;//552

                    break;
                default:
                    
                    break;
            }
            start_game_timer();         //計時遊戲開始
            mines_amount(mines_count);
            create_paint();              //draw line
            create_buttons(row, col);   //產生buttons 列,欄
            create_label(row, col);     //產生Label 列,欄
            create_mines(mines_count, row, col);   //產生Mines 地雷數量,列,欄
            
        }
        /*畫線---------------------------------------------------------------------------------*/
        public void create_paint()
        {
            
            for (int  i = 0; i <= col; i++)
            {
                pan[i] = new Panel();
                pan[i].Enabled = false;
                pan[i].Width = 3;
                pan[i].Top = 30;
                pan[i].Height = this.Height-size-43;
                pan[i].Left = 3+ i * size;
                pan[i].BackColor = Color.Chocolate;
                Controls.Add(pan[i]);
            }
           
            for (int j = col; j < col+row + 1; j++)
            {
                pan[j] = new Panel();
                pan[j].Enabled = false;
                pan[j].Width = this.Width-size+3;
                pan[j].Height = 3;
                pan[j].Left = 3;
                pan[j].Top = -(size * col + size  + 12 + size-100) + j * size;
                pan[j].BackColor = Color.Chocolate;
                Controls.Add(pan[j]);
            }
            
        }
        /*=====================================================================================*/
    }
}
