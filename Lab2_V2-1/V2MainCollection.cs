﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab1_V2
{
    class V2MainCollection : IEnumerable<V2Data>
    {
        private List<V2Data> v2Datas;

        public int Count
        {
            get { return v2Datas.Count; }
        }

        public void Add(V2Data item)
        {
            v2Datas.Add(item);
        }

        public bool Remove(string id, double w)
        {
            bool flag = false;
            for (int i = 0; i < v2Datas.Count; i++)
            {
                if (v2Datas[i].Freq == w && v2Datas[i].Info == id)
                {
                    v2Datas.Remove(v2Datas[i]);
                    flag = true;
                }
            }
            return flag;
        }

        public void AddDefaults()
        {
            Grid1D Ox = new Grid1D(1, 3);
            Grid1D Oy = new Grid1D(1, 3);
            v2Datas = new List<V2Data>();
            V2DataOnGrid[] mag = new V2DataOnGrid[4];
            V2DataCollection[] collections = new V2DataCollection[4];
            for (int i = 0; i < 3; i++)
            {
                //mag[i] = new V2DataOnGrid("Data", 123, Ox, Oy);
                //collections[i] = new V2DataCollection("Data", 123);
                mag[i] = new V2DataOnGrid("Data " + i.ToString(), i, Ox, Oy);
                collections[i] = new V2DataCollection("Collection number:  " + i.ToString(), i);
            }
            for (int i = 0; i < 3; i++)
            {
                mag[i].initRandom(0, 100);
                collections[i].initRandom(4, 10, 10, 0, 100);
                this.Add(mag[i]);
                this.Add(collections[i]);
            }

            Grid1D NULLOX = new Grid1D(0, 0);
            Grid1D NULLOY = new Grid1D(0, 0);
            mag[3] = new V2DataOnGrid("NULL", 10, NULLOX, NULLOY);
            collections[3] = new V2DataCollection("NULL", 10);

            mag[3].initRandom(0, 10);
            collections[3].initRandom(0, 10, 10, 0, 10);
            this.Add(mag[3]);
            this.Add(collections[3]);

        }

        public override string ToString()
        {
            string ret = String.Empty;
            foreach (V2Data data in v2Datas)
                ret += (data.ToString() + '\n');
            return ret;
        }

        public IEnumerator<V2Data> GetEnumerator()
        {
            return ((IEnumerable<V2Data>)v2Datas).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)v2Datas).GetEnumerator();
        }

        public string ToLongString(string format)
        {
            string ret = String.Empty;
            foreach (V2Data data in v2Datas)
                ret += (data.ToLongString(format) + '\n');
            return ret;
        }
        public double Avg
        {
            get
            {
                IEnumerable<DataItem> collection = from elem in (from data in v2Datas
                                                                 where data is V2DataCollection
                                                                 select (V2DataCollection)data)
                                                   from item in elem
                                                   select item;

                IEnumerable<DataItem> mag = from elem in (from data in v2Datas
                                                           where data is V2DataOnGrid
                                                           select (V2DataOnGrid)data)
                                             from item in elem
                                             select item;

                IEnumerable<DataItem> items = collection.Union(mag);

                return items.Average(n => n.Complex.Magnitude);
            }
        }

        public DataItem NearAvg
        {
            get
            {
                double a = this.Avg;

                IEnumerable<DataItem> collection = from elem in (from data in v2Datas
                                                                 where data is V2DataCollection
                                                                 select (V2DataCollection)data)
                                                   from item in elem
                                                   select item;

                IEnumerable<DataItem> mag= from elem in (from data in v2Datas
                                                           where data is V2DataOnGrid
                                                           select (V2DataOnGrid)data)
                                             from item in elem
                                             select item;

                IEnumerable<DataItem> items = collection.Union(mag);

                var dif = from item in items
                          select Math.Abs(item.Complex.Magnitude - a);

                double min = dif.Min();

                var ret = from item in items
                          where Math.Abs(item.Complex.Magnitude - a) <= min
                          select item;

                return ret.First();
            }
        }

        public IEnumerable<Vector2> Vectors
        {
            get
            {
                return from elem in (from data in v2Datas
                                     where data is V2DataCollection
                                     select (V2DataCollection)data)
                       from item in elem
                       select item.Vector;
            }
        }
    }
}
