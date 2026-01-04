/*
 * Copyright 2025 Kitsuri Studios
 * Developed by Astronix (Porush Ajay Kumar)
 *
 * SUMMARY (Apache License 2.0):
 *  You may use, copy, modify, and distribute this software
 *  You may use it for commercial and private purposes
 *  You may sublicense and include it in proprietary projects
 *  You must include this copyright notice and license text
 *  You must state significant changes if you modify the code
 *  You may NOT claim this software as your own original work
 *  No warranty or liability is provided by the authors
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using UnityEngine;
using UnityEngine.EventSystems;

namespace UGPPC.dev.kitsuri.ugppc
{
    public class JoystickController : MonoBehaviour, 
        IPointerDownHandler, IDragHandler,IPointerUpHandler
    {
        public RectTransform background;
        public RectTransform handle;

        public Vector2 InputVector { get; private set; }

        float radius;

        void Start()
        {
            radius = background.sizeDelta.x * 0.5f;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                background, eventData.position, eventData.pressEventCamera, out pos);

            pos = Vector2.ClampMagnitude(pos, radius);
            handle.anchoredPosition = pos;

            InputVector = pos / radius;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            handle.anchoredPosition = Vector2.zero;
            InputVector = Vector2.zero;
        }
    }
}