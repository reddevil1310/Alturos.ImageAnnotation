﻿using Alturos.ImageAnnotation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Alturos.ImageAnnotation.CustomControls
{
    public partial class TagSelectionControl : UserControl
    {
        public List<string> SelectedTags { get; private set; }
        private AnnotationConfig _config;

        public TagSelectionControl()
        {
            this.InitializeComponent();
        }

        public void Setup(AnnotationConfig config)
        {
            this._config = config;
            this.dataGridViewTags.DataSource = this._config.Tags;
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            this.SelectedTags.Clear();

            var rowsSelected = this.dataGridViewTags.SelectedRows;
            foreach (DataGridViewRow row in rowsSelected)
            {
                var tag = row.DataBoundItem as AnnotationPackageTag;
                this.SelectedTags.Add(tag.Value);
            }
        }

        private void TextBoxFilter_TextChanged(object sender, EventArgs e)
        {
            var filter = this.textBoxFilter.Text;
            if (!string.IsNullOrEmpty(filter))
            {
                this.dataGridViewTags.DataSource = this._config.Tags.Where(o => o.Value.Contains(filter)).ToList();
            }
            else
            {
                this.dataGridViewTags.DataSource = this._config.Tags;
            }
        }
    }
}
