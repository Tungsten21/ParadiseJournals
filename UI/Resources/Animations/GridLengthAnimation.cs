using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace UI.Resources.Animations
{
    public class GridLengthAnimation : AnimationTimeline
    {

        public static readonly DependencyProperty FromProperty = DependencyProperty.Register("From", 
            typeof(GridLength), typeof(GridLengthAnimation), new PropertyMetadata(null));
        
        public static readonly DependencyProperty ToProperty = DependencyProperty.Register("To", 
            typeof(GridLength), typeof(GridLengthAnimation), new PropertyMetadata(null));

        public GridLength From
        {
            get => (GridLength) GetValue(FromProperty);
            set => SetValue(FromProperty, value);
        }

        public GridLength To
        {
            get => (GridLength)GetValue(ToProperty);
            set => SetValue(ToProperty, value);
        }

        public override Type TargetPropertyType => typeof(GridLength);

        public GridLengthAnimation()
        {

        }

        public GridLengthAnimation(Duration duration, GridLength? from = null, GridLength? to = null)
        {
            Duration = duration;

            if (from.HasValue)
                From = from.Value;

            if (to.HasValue)
                To = to.Value;
        }

        public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
        {
                double fromVal = ((GridLength)GetValue(GridLengthAnimation.FromProperty)).Value;
                double toVal = ((GridLength)GetValue(GridLengthAnimation.ToProperty)).Value;

                if (fromVal > toVal)
                {
                    return new GridLength((1 - animationClock.CurrentProgress.Value) *
                        (fromVal - toVal) + toVal, GridUnitType.Star);
                }
                else
                {
                    return new GridLength(animationClock.CurrentProgress.Value *
                        (toVal - fromVal) + fromVal, GridUnitType.Star);
            }
        }

        protected override Freezable CreateInstanceCore()
        {
           return new GridLengthAnimation();
        }
    }
}
