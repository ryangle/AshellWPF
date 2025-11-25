using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfControls
{
    /// <summary>
    /// 自定义v形布局
    /// </summary>
    public class VShapePanel : Panel
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            Debug.WriteLine($"size:{availableSize}");
            Size desiredSize = new Size();
            // 测量所有子元素
            foreach (UIElement child in this.InternalChildren)
            {
                // 让子元素自行测量所需大小
                child.Measure(availableSize);

                // 更新面板所需的宽度和高度
                desiredSize.Width = Math.Max(desiredSize.Width, child.DesiredSize.Width * 2);
                desiredSize.Height += child.DesiredSize.Height / 2;
            }

            // 确保V形底部有足够空间
            if (this.InternalChildren.Count > 0)
            {
                var lastChild = this.InternalChildren[this.InternalChildren.Count - 1];
                desiredSize.Height += lastChild.DesiredSize.Height / 2;
            }

            return desiredSize;
        }
        /// <summary>
        /// 重写排列方法，将子元素排列成V形
        /// </summary>
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (this.InternalChildren.Count == 0)
                return finalSize;

            int middleIndex = this.InternalChildren.Count / 2;
            double centerX = finalSize.Width / 2;
            double currentY = 0;

            // 排列V形左侧的元素
            for (int i = 0; i <= middleIndex; i++)
            {
                UIElement child = this.InternalChildren[i];
                double offsetX = centerX - (middleIndex - i) * (child.DesiredSize.Width * 0.75);

                // 排列子元素
                child.Arrange(new Rect(
                    offsetX,
                    currentY,
                    child.DesiredSize.Width,
                    child.DesiredSize.Height));

                currentY += child.DesiredSize.Height / 2;
            }

            // 排列V形右侧的元素
            currentY = 0;
            for (int i = 0; i < middleIndex; i++)
            {
                UIElement child = this.InternalChildren[i];
                UIElement symmetricChild = this.InternalChildren[this.InternalChildren.Count - 1 - i];

                double offsetX = centerX + (middleIndex - i) * (symmetricChild.DesiredSize.Width * 0.75);

                // 排列对称元素
                symmetricChild.Arrange(new Rect(
                    offsetX,
                    currentY,
                    symmetricChild.DesiredSize.Width,
                    symmetricChild.DesiredSize.Height));

                currentY += child.DesiredSize.Height / 2;
            }

            return finalSize;
        }
    }
}
