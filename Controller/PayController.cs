using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amieats.Controller
{
    class PayController
    {
        private View.Pay vPay;
        private Model.TransaksiModel mTransaksi;
        private Model.ItemTransaksiModel mItemTransaksi;

        private string metodePembayaran;
        private string kodeMeja;

        public PayController(View.Pay vPay)
        {
            this.vPay = vPay;
            this.mTransaksi = new Model.TransaksiModel();
            this.mItemTransaksi = new Model.ItemTransaksiModel();
        }

        public void setMetodePembayaran(string metode)
        {
            this.metodePembayaran = metode;
        }

        public void setKodeMeja(string kode)
        {
            this.kodeMeja = kode;
        }

        public void submitTransaction()
        {

            // count total 
            int total = 0;
            foreach(CartItem item in CartitemList.Content)
            {
                total += item.harga * item.qty;
            }

            // create new transaction
            mTransaksi.SetMetode(metodePembayaran);
            mTransaksi.SetTanggal(DateTime.Now.ToString("yyyy-MM-dd"));
            mTransaksi.SetTotal(total);
            mTransaksi.setKodeMeja(kodeMeja);

            int id_transaksi = mTransaksi.InsertTransaksi();

            // create the item
            foreach (CartItem item in CartitemList.Content)
            {
                mItemTransaksi.SetId_transaksi(id_transaksi);
                mItemTransaksi.SetId_menu(item.id_menu);
                mItemTransaksi.SetId_variasi(item.id_variasi);
                mItemTransaksi.SetQty(item.qty);
                mItemTransaksi.SetSubtotal(item.harga);
                mItemTransaksi.setNote(item.catatan);
                mItemTransaksi.SetStatus("pending");
                mItemTransaksi.InsertItemTransaksi();
            }

            // clear the item
            CartitemList.Content.Clear();

        }
    }
}
