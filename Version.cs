namespace PublicAssembly
{
    public readonly struct Version
    {
        private readonly uint _major;
        private readonly uint _minor;
        private readonly uint _patch;

        /// <param name="major">Used for breaking changes</param>
        /// <param name="minor">Used for new content with no breaking changes</param>
        /// <param name="patch">Used for patches</param>
        public Version(uint major, uint minor, uint patch)
        {
            _major = major;
            _minor = minor;
            _patch = patch;
        }

        public override string ToString()
        {
            return $"{_major}.{_minor}.{_patch}";
        }
    }
}