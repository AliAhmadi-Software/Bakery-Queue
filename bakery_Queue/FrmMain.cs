using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bakery_Queue
{
    public partial class FrmMain : Form
    {
        MyQueue queue;
        public int num = 0;//حاجی این مشخصه تو کد هم مقدار دهی کردم تعداد صف هستش
        public int counter = 0;
        //MyQueue queue = new MyQueue(num);//سجاد کونده ریده ببین اینجا باید یه عدد بدی بفهمی این عدده چیه حله
       /* public FrmMain(MyQueue myQueue, int number)
        {
            InitializeComponent();
            this.queue = myQueue;
            this.num = number;
        }*/
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            txtNumBread.Enabled = false;
            BtnAdd.Enabled = false;
            BtnNext.Enabled = false;
            //queue = new MyQueue(num);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            txtNumBread.Enabled = true;
            BtnAdd.Enabled = true;
            BtnNext.Enabled = true;
            //****************************//
            num = int.Parse(txtNumQueue.Value.ToString());
            queue = new MyQueue(num);
            queue = queue.createQueue(num);// createQueue(num);
        }
       

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (counter != 0)
            {

                while (queue.isEmpty())
                {
                    queue = queue.next;
                }

                CellType turn = queue.deQueue();
                counter--;

                lblCode.Text = "Code:" + " " + turn.code + " " + "Bread:" + " " + queue.number;

                queue = queue.next;

            }
            else
            {
                MessageBox.Show("Queues Are Empty!","No One In Queue",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void add()
        {

            string get = txtNumBread.Value.ToString();
            if (get != null)
            {
                int count;
                try
                {
                    count = int.Parse(get);
                    if (count < 1 || count > num)
                    {
                        showError();
                    }
                    else
                    {
                        addToQueue(count);
                        counter++;
                        
                    }
                }
                catch (Exception )
                {
                    showError();
                }
            }

        }

        private void showError()
        {
            MessageBox.Show("Enter A Valid Number!", "Invalid Number", MessageBoxButtons.OK,MessageBoxIcon.Error);
            //add();
        }

        private void addToQueue(int count)
        {

            MyQueue queue = this.queue;

            while (true)
            {

                if (queue.number == count)
                {
                    queue.enQueue(count);
                    break;
                }
                else
                {
                    queue = queue.next;
                }

            }

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            add();
        }

    }
}
