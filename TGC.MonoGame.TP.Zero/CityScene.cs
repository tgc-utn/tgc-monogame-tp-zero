﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TGC.MonoGame.TP.Zero;

/// <summary>
///     A City Scene to be drawn.
/// </summary>
internal class CityScene
{
    private const float DistanceBetweenCities = 2100f;

    private readonly Effect _effect;
    private readonly Model _model;
    private readonly List<Matrix> _worldMatrices;

    /// <summary>
    ///     Creates a City Scene with a content manager to load resources.
    /// </summary>
    /// <param name="content">The Content Manager to load resources</param>
    /// <param name="contentFolder3D">The name folder with the 3D models</param>
    /// <param name="contentFolderEffects">The name folder with the shaders</param>
    public CityScene(ContentManager content, string contentFolder3D, string contentFolderEffects)
    {
        // Load the City Model.
        _model = content.Load<Model>(contentFolder3D + "scene/city");

        // Load an effect that will be used to draw the scene.
        _effect = content.Load<Effect>(contentFolderEffects + "BasicShader");

        // Get the first texture we find.
        // The city model only contains a single texture.
        var effect = _model.Meshes.FirstOrDefault()?.Effects.FirstOrDefault() as BasicEffect;
        var texture = effect.Texture;

        // Set the Texture to the Effect.
        _effect.Parameters["ModelTexture"].SetValue(texture);

        // Assign the mesh effect.
        // A model contains a collection of meshes.
        foreach (var mesh in _model.Meshes)
        {
            // A mesh contains a collection of parts.
            foreach (var meshPart in mesh.MeshParts)
                // Assign the loaded effect to each part.
            {
                meshPart.Effect = _effect;
            }
        }

        // Create a list of places where the city model will be drawn.
        _worldMatrices = new List<Matrix>
        {
            Matrix.Identity,
            Matrix.CreateTranslation(Vector3.Right * DistanceBetweenCities),
            Matrix.CreateTranslation(Vector3.Left * DistanceBetweenCities),
            Matrix.CreateTranslation(Vector3.Forward * DistanceBetweenCities),
            Matrix.CreateTranslation(Vector3.Backward * DistanceBetweenCities),
            Matrix.CreateTranslation((Vector3.Forward + Vector3.Right) * DistanceBetweenCities),
            Matrix.CreateTranslation((Vector3.Forward + Vector3.Left) * DistanceBetweenCities),
            Matrix.CreateTranslation((Vector3.Backward + Vector3.Right) * DistanceBetweenCities),
            Matrix.CreateTranslation((Vector3.Backward + Vector3.Left) * DistanceBetweenCities)
        };
    }

    /// <summary>
    ///     Draws the City Scene.
    /// </summary>
    /// <param name="gameTime">The Game Time for this frame</param>
    /// <param name="view">A view matrix, generally from a camera</param>
    /// <param name="projection">A projection matrix</param>
    public void Draw(GameTime gameTime, Matrix view, Matrix projection)
    {
        // Set the View and Projection matrices, needed to draw every 3D model.
        _effect.Parameters["View"].SetValue(view);
        _effect.Parameters["Projection"].SetValue(projection);

        // Get the base transform for each mesh.
        // These are center-relative matrices that put every mesh of a model in their corresponding location.
        var modelMeshesBaseTransforms = new Matrix[_model.Bones.Count];
        _model.CopyAbsoluteBoneTransformsTo(modelMeshesBaseTransforms);

        // For each mesh in the model.
        foreach (var mesh in _model.Meshes)
        {
            // Obtain the world matrix for that mesh (relative to the parent).
            var meshWorld = modelMeshesBaseTransforms[mesh.ParentBone.Index];

            // Then for each world matrix.
            foreach (var worldMatrix in _worldMatrices)
            {
                // We set the main matrices for each mesh to draw.
                _effect.Parameters["World"].SetValue(meshWorld * worldMatrix);

                // Draw the mesh.
                mesh.Draw();
            }
        }
    }
}