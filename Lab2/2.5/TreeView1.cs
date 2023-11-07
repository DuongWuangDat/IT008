using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._5
{
    public partial class Form1
    {
        private TreeNode selectedItem;

        private void InitializeTreeView()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            TreeNode rootNode = new TreeNode("My Computer");

            foreach (DriveInfo drive in drives)
            {
                TreeNode driveNode = new TreeNode(drive.Name);
                driveNode.Tag = drive.RootDirectory.FullName;
                rootNode.Nodes.Add(driveNode);
            }

            treeView.Nodes.Add(rootNode);

            treeView.AfterSelect += treeView_AfterSelect;
        }

        private void StoreSelectedItem(TreeNode item)
        {
            selectedItem = item;
        }    

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Xóa bất kỳ mục nào cũ trong ListView
            listView.Items.Clear();

            // Lấy node được chọn
            TreeNode selectedNode = e.Node;

            StoreSelectedItem(selectedNode);

            // Lấy đường dẫn từ thuộc tính Tag của node
            string path = selectedNode.Tag as string;

            if (!string.IsNullOrEmpty(path))
            {
                // Xóa nút con cũ trước khi thêm nút mới
                selectedNode.Nodes.Clear();

                // Lấy danh sách thư mục con
                try
                {
                    string[] directories = Directory.GetDirectories(path);

                    // Thêm các thư mục con làm nút con của nút hiện tại
                    foreach (string directory in directories)
                    {
                        TreeNode dirNode = new TreeNode(Path.GetFileName(directory));
                        dirNode.Tag = directory;
                        selectedNode.Nodes.Add(dirNode);

                        DirectoryInfo dirInfo = new DirectoryInfo(directory);

                        // Tạo một ListViewItem với thông tin về thư mục con
                        ListViewItem item = new ListViewItem(dirInfo.Name);
                        item.Tag = dirInfo.FullName;
                        item.SubItems.Add("Thư mục"); // Loại

                        // Thêm item vào ListView
                        listView.Items.Add(item);
                    }

                    string[] files = Directory.GetFiles(path);

                    foreach (string file in files)
                    {
                        // Lấy thông tin về tệp con
                        FileInfo fileInfo = new FileInfo(file);

                        // Tạo một ListViewItem với thông tin về tệp con
                        ListViewItem item = new ListViewItem(fileInfo.Name);
                        item.Tag = fileInfo.FullName;
                        item.SubItems.Add("Tệp"); // Loại

                        // Thêm item vào ListView
                        listView.Items.Add(item);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    // Xử lý trường hợp không có quyền truy cập vào thư mục
                    MessageBox.Show("Access denied to this folder.");
                }
            }
        }
    }
}