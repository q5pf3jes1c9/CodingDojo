using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class Game
    {
        private List<Frame> _frames = new List<Frame>();

        public void AddRoll(int pins)
        {
            if (Over())
            {
                throw new Exception("Game is over; No more pins can be added.");
            }

            var frames = Frames();
            var isNewFrameRequired = IsNewFrameRequired(frames);
            AddFrameIfNewRequired(frames, isNewFrameRequired);
            UpdatePins(frames, pins);
            StoreFrames(frames);
        }

        private void StoreFrames(List<Frame> frames)
        {
            _frames = frames;
        }

        public List<Frame> Frames() => _frames;
        public int TotalScore() => _frames.Sum(frame => frame.Score);

        public bool Over()
        {
            var frames = _frames;
            var lastFrame = GetLastFrame(frames);
            return Has10Frames(_frames) && lastFrame.IsScoreFinished();
        }

        private static bool HasNoFrames(ICollection frames) => frames.Count == 0;
        private static bool Has10Frames(ICollection frames) => frames.Count == 10;

        private static Frame GetLastFrame(List<Frame> frames)
        {
            if (frames.Any())
            {
                return frames[^1];
            }
            return null;
        }
        
        private static bool IsNewFrameRequired(List<Frame> frames)
        {
            if (HasNoFrames(frames))
            {
                return true;
            }

            if (Has10Frames(frames))
            {
                return false;
            }

            var lastFrame = GetLastFrame(frames);
            return !lastFrame.IsNormalFrame() || lastFrame.HasExact2Roles();
        }
        
        private static void UpdatePins(IEnumerable<Frame> frames, in int pins)
        {
            var notFinishedFrames = GetScoreNotFinishedFrames(frames);
            foreach (var frame in notFinishedFrames)
            {
                AddRollToFrame(frame, pins);
            }
        }
        
        private static void AddRollToFrame(Frame frame, in int pins)
        {
            frame.PinsRolled.Add(pins);
        }

        private static IEnumerable<Frame> GetScoreNotFinishedFrames(IEnumerable<Frame> frames)
        {
            return frames.TakeLast(3).Where(frame => !frame.IsScoreFinished()).ToList();
        }

        private static void AddFrameIfNewRequired(List<Frame> frames, bool isNewFrameRequired)
        {
            if (isNewFrameRequired)
            {
                var frameToAdd = new Frame();
                frames.Add(frameToAdd);
            }
        }
    }
}