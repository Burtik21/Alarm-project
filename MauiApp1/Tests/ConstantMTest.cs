using Xunit;

namespace MauiApp1.Tests
{
    public class ConstantsMTest
    {
        [Fact]
        public void DefaultTime_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal("7:00", MauiApp1.ConstantsM.ConstantsM.DefaultTime);
        }

        [Fact]
        public void AlarmDurationText_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal("Doba budíku", MauiApp1.ConstantsM.ConstantsM.AlarmDurationText);
        }

        [Fact]
        public void ErrorTitle_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal("Error", MauiApp1.ConstantsM.ConstantsM.ErrorTitle);
        }

        [Fact]
        public void OkText_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal("OK", MauiApp1.ConstantsM.ConstantsM.OkText);
        }

        [Fact]
        public void AlarmSwitchText_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal("Zapnout budík", MauiApp1.ConstantsM.ConstantsM.AlarmSwitchText);
        }

        [Fact]
        public void ApiEndPointCas_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal("http://141.147.16.43/api/cas/", MauiApp1.ConstantsM.ConstantsM.ApiEndPointCas);
        }

        [Fact]
        public void ApiEndPointIsOn_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal("http://141.147.16.43/api/is_on/", MauiApp1.ConstantsM.ConstantsM.ApiEndPointIsOn);
        }

        [Fact]
        public void ApiEndPointAlarmDuration_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal("http://141.147.16.43/api/alarm_duration/", MauiApp1.ConstantsM.ConstantsM.ApiEndPointAlarmDuration);
        }

        [Fact]
        public void ApiEndPointPressed_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal("http://141.147.16.43/api/pressed/", MauiApp1.ConstantsM.ConstantsM.ApiEndPointPressed);
        }

        [Fact]
        public void ApiEndPointPalarmDurationHistory_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal("http://141.147.16.43/api/alarm_duration_history/", MauiApp1.ConstantsM.ConstantsM.ApiEndPointPalarmDurationHistory);
        }

        [Fact]
        public void ApiEndPointVolume_ShouldBeCorrect()
        {
            // Assert
            Assert.Equal("http://141.147.16.43/api/volume/", MauiApp1.ConstantsM.ConstantsM.ApiEndPointVolume);
        }
    }
}
