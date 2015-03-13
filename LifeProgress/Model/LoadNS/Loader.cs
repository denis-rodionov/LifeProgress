using System;
using System.Collections.Generic;
using System.Text;
using ModelNS.Interfaces;
using System.IO;
using System.Collections;
using Manager;

namespace ModelNS.LoadNS
{
    class Loader
    {
        // data
        ArrayList _objStorage = new ArrayList();

        //---------------------------------------------------------------------------
        public Loader()
        {
        }

        //---------------------------------------------------------------------------
        public void loadModel(Model model, string fName)
        {
            lock(fName + "load")
            {
                FileStream fs = null;
                BinaryReader br = null;
                try
                {
                    fs = new FileStream(fName, FileMode.Open);
                    br = new BinaryReader(fs);

                    int ver = loadVersion(br);
                    model = load(br, ver);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.logException(ex);
                }
                finally
                {
                    if (br != null) br.Close();
                    if (fs != null) fs.Close();
                }
            }
        }

        //---------------------------------------------------------------------------
        private int loadVersion(BinaryReader br)
        {
            return br.ReadInt32();
        }

        //---------------------------------------------------------------------------
        public Model load(BinaryReader br, int ver)
        {
            Model mod = Model.instance();
            switch (ver)
            {
                case 1: 
                case 2:
                case 3:
                    load_1(br);
                    break;
                default:
                    throw new Exception("Невозможно загрузить данную версию модели!");
            }
            return mod;
        }

        //---------------------------------------------------------------------------
        private void load_1(BinaryReader br)
        {
            ItemType type = 0;
            int version = 0;
            int id = 0;

            while (true)
            {
                try
                {
                    readHeader(ref type, ref version, ref id, br);
                    ILoader ldr = findLoader(type);
                    object obj = ldr.load(id, br, version, _objStorage);
                    _objStorage.Add(obj);
                }
                catch (EndOfStreamException)
                {
                    break;
                }
                catch 
                {
                    throw new Exception("Неудалось прочитать файл");
                }
            }
        }

        //---------------------------------------------------------------------------
        private ILoader findLoader(ItemType type)
        {
            ILoader res = null;
            switch (type)
            {
                case ItemType.DEBT_LIST:
                    res = new DebtListLoader();
                    break;
                case ItemType.FIELD_TEMPLATE:
                    res = new FieldTemplateLoader();
                    break;
                case ItemType.MODEL:
                    res = new ModelLoader();
                    break;
                case ItemType.NUMBER_TASK:
                    res = new NumberTaskLoader();
                    break;
                case ItemType.PERCENT_TASK:
                    res = new PercentTaskLoader();
                    break;
                case ItemType.PLAIN_TASK:
                    res = new PlainTaskLoader();
                    break;
                case ItemType.TEMPLATE_TASK:
                    res = new TemplateTaskLoader();
                    break;
                case ItemType.TEMPLATES:
                    res = new TemplatesLoader();
                    break;
                case ItemType.WEEK:
                    res = new WeekLoader();
                    break;
                case ItemType.WEEK_FIELD:
                    res = new WeekFieldLoader();
                    break;
                case ItemType.WEEK_LIST:
                    res = new WeekListLoader();
                    break;
                case ItemType.WORK_FIELD:
                    res = new WorkFieldLoader();
                    break;
                case ItemType.INPUT_DATA:
                    res = new InputDataLoader();
                    break;
                case ItemType.DAY_INPUT:
                    res = new DayInputLoader();
                    break;
            }
            return res;
        }

        //---------------------------------------------------------------------------
        private void readHeader(ref ItemType type, ref int version, ref int id, BinaryReader br)
        {
            type = (ItemType)br.ReadInt32();
            version = br.ReadInt32();
            id = br.ReadInt32();
        }
    }
}
