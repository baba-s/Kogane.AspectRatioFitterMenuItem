using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Kogane.Internal
{
    internal static class AspectRatioFitterMenuItem
    {
        [MenuItem( "CONTEXT/AspectRatioFitter/Set Default Aspect Ratio" )]
        private static void SetDefaultAspectRatio( MenuCommand menuCommand )
        {
            var aspectRatioFitter  = ( AspectRatioFitter )menuCommand.context;
            var defaultAspectRatio = GetDefaultAspectRatio( aspectRatioFitter );

            Undo.RecordObject( aspectRatioFitter, "Set Default Aspect Ratio" );

            aspectRatioFitter.aspectRatio = defaultAspectRatio;
        }

        private static float GetDefaultAspectRatio( Component component )
        {
            if ( component.TryGetComponent<Image>( out var image ) )
            {
                var sprite = image.sprite;
                var rect   = sprite.rect;

                return rect.width / rect.height;
            }

            if ( component.TryGetComponent<RawImage>( out var rawImage ) )
            {
                var texture = rawImage.texture;

                return ( float )texture.width / texture.height;
            }

            return 0;
        }
    }
}