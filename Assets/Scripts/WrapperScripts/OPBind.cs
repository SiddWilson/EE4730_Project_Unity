using System;
using System.Runtime.InteropServices;

namespace OpenPose {

    public static class OPBind {

        // Output callback delegate
        public delegate void OutputCallback(IntPtr ptrs, int ptrSize, IntPtr sizes, int sizeSize, byte outputType);

        // Logging callback delegate
        public delegate void DebugCallback(string message, int type);

        [DllImport("openpose")] public static extern void _OPRegisterOutputCallback(OutputCallback callback);

        [DllImport("openpose")] public static extern void _OPSetOutputEnable(bool enable);

        [DllImport("openpose")] public static extern void _OPRegisterDebugCallback(DebugCallback callback);

        [DllImport("openpose")] public static extern void _OPSetDebugEnable(bool enable);

        [DllImport("openpose")] public static extern void _OPSetImageOutputEnable(bool enable);

        [DllImport("openpose")] public static extern void _OPRun();

        [DllImport("openpose")] public static extern void _OPShutdown();

        [DllImport("openpose")] public static extern void _OPConfigurePose(
            byte poseMode, int netInputSizeX, int netInputSizeY, // Point
            int outputSizeX, int outputSizeY, // Point
            byte keypointScaleMode, // ScaleMode
            int gpuNumber, int gpuNumberStart, int scalesNumber, float scaleGap,
            byte renderMode, // RenderMode
            byte poseModel, // PoseModel
            bool blendOriginalFrame, float alphaKeypoint, float alphaHeatMap, int defaultPartToRender,
            string modelFolder, bool heatMapAddParts, bool heatMapAddBkg,
            bool heatMapAddPAFs, // vector<HeatMapType>
            byte heatMapScaleMode, // ScaleMode
            bool addPartCandidates, float renderThreshold, int numberPeopleMax,
            bool maximizePositives, double fpsMax, string protoTxtPath, string caffeModelPath, float upsamplingRatio
        );
        [DllImport("openpose")] public static extern void _OPConfigureHand(
            bool enable, byte detector, int netInputSizeX, int netInputSizeY, // Point
            int scalesNumber, float scaleRange, byte renderMode, // RenderMode
            float alphaKeypoint, float alphaHeatMap, float renderThreshold
        );
        [DllImport("openpose")] public static extern void _OPConfigureFace(
            bool enable, byte detector, int netInputSizeX, int netInputSizeY, // Point
            byte renderMode, // RenderMode
            float alphaKeypoint, float alphaHeatMap, float renderThreshold
        );
        [DllImport("openpose")] public static extern void _OPConfigureExtra(
            bool reconstruct3d, int minViews3d, bool identification, int tracking, int ikThreads
        );
        [DllImport("openpose")] public static extern void _OPConfigureInput(
            byte producerType, string producerString, // ProducerType and string
            ulong frameFirst, ulong frameStep, ulong frameLast,
            bool realTimeProcessing, bool frameFlip, int frameRotate, bool framesRepeat,
            int cameraResolutionX, int cameraResolutionY, // Point
            string cameraParameterPath, bool undistortImage, int numberViews
        );
        [DllImport("openpose")] public static extern void _OPConfigureOutput(
            double verbose, string writeKeypoint, byte writeKeypointFormat, // DataFormat
            string writeJson, string writeCocoJson, int writeCocoJsonVariants, int writeCocoJsonVariant,
            string writeImages, string writeImagesFormat, string writeVideo, double writeVideoFps, bool writeVideoWithAudio,
            string writeHeatMaps, string writeHeatMapsFormat, string writeVideo3D, string writeVideoAdam,
            string writeBvh, string udpHost, string udpPort
        );
        [DllImport("openpose")] public static extern void _OPConfigureGui(
            ushort displayMode, // DisplayMode
            bool guiVerbose, bool fullScreen
        );
        [DllImport("openpose")] public static extern void _OPConfigureDebugging(
            byte loggingLevel, // Priority
			bool disableMultiThread, ulong profileSpeed
        );
    }
}
