namespace Assets.Code.Editor
{
    internal class TextureImporter : UnityEditor.AssetPostprocessor { 
        internal void OnPreprocessTexture()
        {
            var texture_importer = (UnityEditor.TextureImporter)this.assetImporter;
            texture_importer.spritePixelsPerUnit = 1;
            texture_importer.textureCompression = UnityEditor.TextureImporterCompression.Uncompressed;
        }
    }
}
