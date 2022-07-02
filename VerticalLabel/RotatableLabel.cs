using System.ComponentModel;

namespace VerticalLabel
{
    public partial class RotatableLabel : UserControl
    {
        public RotatableLabel()
        {
            InitializeComponent();
            _text = string.IsNullOrEmpty(base.Text)?this.Name:base.Text;
            _rotateFlipType = RotateFlipType.RotateNoneFlipNone;
            _texAlignment = ContentAlignment.MiddleLeft;
            this.Size = new Size(150, 21);
        }

        private string _text;
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always),
            Description("Test text displayed in the textbox"), Category("Data")]
        public new string Text
        {
            get => _text;
            set
            {
                _text = value;
                RotatableLabel_Paint();
            }
        }


        private RotateFlipType _rotateFlipType;
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always),
         Description("Test text displayed in the textbox"), Category("Data")]
        public RotateFlipType RotateFlipType
        {
            get => _rotateFlipType;
            set
            {
                _rotateFlipType = value;
                RotatableLabel_Paint();
            }
        }


        private ContentAlignment _texAlignment;
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always),
         Description("Test text displayed in the textbox"), Category("Data")]
        public ContentAlignment TextAlignment
        {
            get => _texAlignment;
            set
            {
                _texAlignment = value;
                RotatableLabel_Paint();
            }
        }



        private void RotatableLabel_Paint()
        {

            switch (_rotateFlipType)
            {
                case RotateFlipType.RotateNoneFlipX:
                case RotateFlipType.RotateNoneFlipXY:
                case RotateFlipType.RotateNoneFlipY:
                case RotateFlipType.RotateNoneFlipNone:
                    var horizontalBitmap = new Bitmap(this.Width, this.Height);
                    var horizontalLabel = new Label() { Text = _text, Font = this.Font, Size = this.Size, TextAlign = TextAlignment,RightToLeft = this.RightToLeft};
                    horizontalLabel.DrawToBitmap(horizontalBitmap, new Rectangle(0, 0, this.Width, this.Height));
                    horizontalLabel.Dispose();
                    horizontalBitmap.RotateFlip(_rotateFlipType);
                    this.BackgroundImage = horizontalBitmap;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case RotateFlipType.Rotate270FlipX:
                case RotateFlipType.Rotate270FlipXY:
                case RotateFlipType.Rotate270FlipY:
                case RotateFlipType.Rotate270FlipNone:
                    var verticalBitmap = new Bitmap(this.Height, this.Width);
                    var verticalLabel = new Label() { Text = _text, Font = this.Font, AutoSize = true, Size = new Size(this.Height, this.Width), TextAlign = TextAlignment,RightToLeft = this.RightToLeft};
                    verticalLabel.DrawToBitmap(verticalBitmap, new Rectangle(0, 0, this.Height, this.Width));
                    verticalLabel.Dispose();
                    verticalBitmap.RotateFlip(_rotateFlipType);
                    this.BackgroundImage = verticalBitmap;
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    break;

            }
        }

        private void RotatableLabelControl_FontChanged(object sender, EventArgs e)
        {
            RotatableLabel_Paint();
        }

        private void RotatableLabelControl_SizeChanged(object sender, EventArgs e)
        {
            RotatableLabel_Paint();
        }
    }
}
