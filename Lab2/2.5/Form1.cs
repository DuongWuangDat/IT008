using System;
using System.IO;
using System.Windows.Forms;

namespace _2._5
{
    public partial class Form1 : Form
    {
        private string copyOrCut;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Windows Explorer";
            InitializeListView();
            InitializeTreeView();
        }



        private void InitializeListView()
        {
            listView.Columns.Add("Tên", 300);
            listView.Columns.Add("Loại", 300);
        }

        private void largesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            listView.View = View.LargeIcon;
        }

        private void smallIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView.View = View.SmallIcon;
        }

        private void listToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            listView.View = View.List;
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView.View = View.Details;
        }

        private void largeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView.View = View.LargeIcon;
        }

        private void smallIconsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView.View = View.SmallIcon;
        }

        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView.View = View.List;
        }

        private void detailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listView.View = View.Details;
        }

        private void renameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];
                string newName = InputDialog.ShowDialog("Rename Item", "Enter new name:");

                string oldPath = selectedItem.Tag as string;
                string newPath = Path.Combine(Path.GetDirectoryName(oldPath), newName);

                if (!string.IsNullOrWhiteSpace(newName) && File.Exists(oldPath))
                {
                    try
                    {
                        File.Move(oldPath, newPath);
                        MessageBox.Show("Tệp tin đã được đổi tên thành: " + newName);
                        selectedItem.Text = newName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
                else if (!string.IsNullOrWhiteSpace(newName) && Directory.Exists(oldPath))
                {
                    try
                    {
                        Directory.Move(oldPath, newPath);
                        MessageBox.Show("Thư mục đã được đổi tên thành: " + newName);
                        selectedItem.Text = newName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên mới và đảm bảo tệp tin hoặc thư mục cũ tồn tại.");
                }
            }
        }

        private void deleteDelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tệp được chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem item in listView.SelectedItems)
                    {

                        string selectedPath = item.Tag as string;
                        if (File.Exists(selectedPath))
                        {
                            try
                            {
                                File.Delete(selectedPath);
                                listView.Items.Remove(item); // Xóa mục khỏi ListView
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi xóa tệp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (Directory.Exists(selectedPath))
                        {
                            try
                            {
                                Directory.Delete(selectedPath);
                                listView.Items.Remove(item);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi xóa thư mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hoặc nhiều tệp cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                string sourcePath = listView.SelectedItems[0].Tag as string;
                Clipboard.SetData(DataFormats.Text, sourcePath);
                copyOrCut = "copy";
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                string sourcePath = listView.SelectedItems[0].Tag as string;
                Clipboard.SetData(DataFormats.Text, sourcePath);
                listView.Items.Remove(listView.SelectedItems[0]);
                copyOrCut = "cut";
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sourcePath = Clipboard.GetData(DataFormats.Text) as string;
            string targetPath = this.selectedItem.Tag as string;

            if (!string.IsNullOrEmpty(sourcePath) && !string.IsNullOrEmpty(targetPath))
            {
                try
                {
                    if (File.Exists(sourcePath))
                    {
                        // Sao chép tệp từ nguồn (sourcePath) đến thư mục đích (targetPath)
                        string fileName = Path.GetFileName(sourcePath);
                        string destinationPath = Path.Combine(targetPath, fileName);

                        File.Copy(sourcePath, destinationPath);
                        if (copyOrCut == "cut")
                        {
                            File.Delete(sourcePath);
                        }
                    }
                    else if (Directory.Exists(sourcePath))
                    {
                        // Sao chép thư mục từ nguồn (sourcePath) đến thư mục đích (targetPath)
                        string folderName = new DirectoryInfo(sourcePath).Name;
                        string destinationPath = Path.Combine(targetPath, folderName);

                        CopyDirectory(sourcePath, destinationPath);

                        if (copyOrCut == "cut")
                        {
                            Directory.Delete(sourcePath);
                        }
                    }

                    // Hiển thị thông báo khi sao chép hoàn thành
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi paste: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Cập nhật listview
            if (copyOrCut == "cut" || copyOrCut == "copy")
            {
                refreshListView();
            }
        }

        // Copy Directory
        private void CopyDirectory(string sourceDir, string destDir)
        {
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            string[] files = Directory.GetFiles(sourceDir);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destDir, name);
                File.Copy(file, dest);
            }

            string[] dirs = Directory.GetDirectories(sourceDir);
            foreach (string dir in dirs)
            {
                string name = Path.GetFileName(dir);
                string dest = Path.Combine(destDir, name);
                CopyDirectory(dir, dest);
            }
        }

        private void refreshListView()
        {
            listView.Items.Clear();

            // Lấy node được chọn
            TreeNode selectedNode = selectedItem;

            // Lấy đường dẫn từ thuộc tính Tag của node
            string path = selectedNode.Tag as string;

            if (!string.IsNullOrEmpty(path))
            {
                // Lấy danh sách thư mục con
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
        }

        private void refreshStripButton_Click(object sender, EventArgs e)
        {
            refreshListView();
        }

        private void upStripButton_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có nút nào được chọn trong TreeView không
            if (treeView.SelectedNode != null)
            {
                TreeNode selectedNode = treeView.SelectedNode;

                // Kiểm tra xem nút hiện tại có nút cha không
                if (selectedNode.Parent != null)
                {
                    // Lấy nút cha của nút hiện tại
                    TreeNode parentNode = selectedNode.Parent;

                    // Chọn nút cha
                    treeView.SelectedNode = parentNode;
                }
                else
                {
                    // Nút hiện tại không có nút cha, không thể nhảy lên.
                    MessageBox.Show("Thư mục hiện tại không có thư mục cha.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Không có nút nào được chọn trong TreeView.
                MessageBox.Show("Vui lòng chọn một thư mục trong TreeView trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void copyStripButton_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                string sourcePath = listView.SelectedItems[0].Tag as string;
                Clipboard.SetData(DataFormats.Text, sourcePath);
                copyOrCut = "copy";
            }
        }

        private void cutStripButton_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                string sourcePath = listView.SelectedItems[0].Tag as string;
                Clipboard.SetData(DataFormats.Text, sourcePath);
                listView.Items.Remove(listView.SelectedItems[0]);
                copyOrCut = "cut";
            }
        }

        private void deleteStripButton_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tệp được chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem item in listView.SelectedItems)
                    {

                        string selectedPath = item.Tag as string;
                        if (File.Exists(selectedPath))
                        {
                            try
                            {
                                File.Delete(selectedPath);
                                listView.Items.Remove(item); // Xóa mục khỏi ListView
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi xóa tệp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (Directory.Exists(selectedPath))
                        {
                            try
                            {
                                Directory.Delete(selectedPath);
                                listView.Items.Remove(item);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi xóa thư mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hoặc nhiều tệp cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pasteStripButton_Click(object sender, EventArgs e)
        {
            string sourcePath = Clipboard.GetData(DataFormats.Text) as string;
            string targetPath = this.selectedItem.Tag as string;

            if (!string.IsNullOrEmpty(sourcePath) && !string.IsNullOrEmpty(targetPath))
            {
                try
                {
                    if (File.Exists(sourcePath))
                    {
                        // Sao chép tệp từ nguồn (sourcePath) đến thư mục đích (targetPath)
                        string fileName = Path.GetFileName(sourcePath);
                        string destinationPath = Path.Combine(targetPath, fileName);

                        File.Copy(sourcePath, destinationPath);
                        if (copyOrCut == "cut")
                        {
                            File.Delete(sourcePath);
                        }
                    }
                    else if (Directory.Exists(sourcePath))
                    {
                        // Sao chép thư mục từ nguồn (sourcePath) đến thư mục đích (targetPath)
                        string folderName = new DirectoryInfo(sourcePath).Name;
                        string destinationPath = Path.Combine(targetPath, folderName);

                        CopyDirectory(sourcePath, destinationPath);

                        if (copyOrCut == "cut")
                        {
                            Directory.Delete(sourcePath);
                        }
                    }

                    // Hiển thị thông báo khi sao chép hoàn thành
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi paste: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Cập nhật listview
            if (copyOrCut == "cut" || copyOrCut == "copy")
            {
                refreshListView();
            }
        }
    }
}

