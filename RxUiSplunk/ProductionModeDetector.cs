using Splat;

namespace RxUiSplunk
{
    public class ProductionModeDetector : IModeDetector
    {
        public static readonly ProductionModeDetector Instance = new ProductionModeDetector();

        protected ProductionModeDetector() { }

        public bool? InDesignMode() => false;
        public bool? InUnitTestRunner() => false;
    }
}