﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.UserInterface;
using osuTK;

namespace osu.Framework.Tests.Visual.UserInterface
{
    public class TestSceneCheckboxes : FrameworkTestScene
    {
        public override IReadOnlyList<Type> RequiredTypes => new[]
        {
            typeof(Checkbox),
            typeof(BasicCheckbox)
        };

        public TestSceneCheckboxes()
        {
            BasicCheckbox swap, rotate;

            Children = new Drawable[]
            {
                new FillFlowContainer
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Direction = FillDirection.Vertical,
                    Spacing = new Vector2(0, 10),
                    Padding = new MarginPadding(10),
                    AutoSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        new BasicCheckbox
                        {
                            LabelText = @"Basic Test"
                        },
                        new BasicCheckbox
                        {
                            LabelText = @"FadeDuration Test",
                            FadeDuration = 300
                        },
                        swap = new BasicCheckbox
                        {
                            LabelText = @"Checkbox Position",
                        },
                        rotate = new BasicCheckbox
                        {
                            LabelText = @"Enabled/Disabled Actions Test",
                        },
                    }
                }
            };

            swap.Current.ValueChanged += check => swap.RightHandedCheckbox = check.NewValue;
            rotate.Current.ValueChanged += e => rotate.RotateTo(e.NewValue ? 45 : 0, 100);
        }
    }
}
