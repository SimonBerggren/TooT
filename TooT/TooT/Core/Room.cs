using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TooT
{
    class Room
    {
        List<GameObject> mObjects;
        List<GameObject> mFlaggedForRemoval;
        internal Vector2 Anchor { get { return mPosition; } }
        private Vector2 mPosition;
        internal Room()
        {
            mPosition = Vector2.Zero;
            mObjects = new List<GameObject>();
            mFlaggedForRemoval = new List<GameObject>();
        }

        internal void Update(GameTime _GT)
        {
            foreach (GameObject obj in mObjects)
                obj.Update(_GT);
            foreach (GameObject obj in mFlaggedForRemoval)
            {
                mObjects.Remove(obj);
                EventManager.Fire(Event.OnObjectRemove, obj);
            }
        }

        internal void Draw(SpriteBatch _SB)
        {
            foreach (GameObject obj in mObjects)
                obj.Draw(_SB);
        }

        internal void AddGameObject(GameObject _Obj)
        {
            mObjects.Add(_Obj);
            _Obj.SetParent(this);
            EventManager.Subscribe(Event.OnObjectFlaggedRemove, new Action(() => AddToRemoveList(_Obj)));
        }

        private void AddToRemoveList(GameObject _Obj)
        {
            mFlaggedForRemoval.Add(_Obj);
        }

        internal void SetPosition(Vector2 _NewPos)
        {
            mPosition = _NewPos;
        }
    }
}
