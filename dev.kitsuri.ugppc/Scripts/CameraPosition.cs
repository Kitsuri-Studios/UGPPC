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

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 CameraPos = transform.position;
        cam.transform.position = CameraPos;
    }
}
