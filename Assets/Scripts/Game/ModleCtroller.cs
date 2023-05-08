using UnityEngine;
using QFramework;
using DG.Tweening;
using Cinemachine.Utility;
using Cinemachine;
using HighlightPlus;
using Doozy.Engine.UI;

namespace QFramework.Example
{
    public partial class ModleCtroller : ViewController, IController, ISingleton
    {
        private AnimatorFSMModel mAnimatorFSMModel;
        public GameObject[] ModlesGlass;
        public CinemachineVirtualCamera[] camerasVirtual;
        public Animation[] animations;
        public GameObject[] GlassStayles;
        public static ModleCtroller Instance
        {
            get { return SingletonProperty<ModleCtroller>.Instance; }
        }
        private ModleCtroller()
        {

        }
        void Start()
        {
            mAnimatorFSMModel = this.GetModel<AnimatorFSMModel>();
            StepMainExperiment();
        }
        public void SetGlassStyle(string tag)
        {
            for (int i = 0; i < ModlesGlass.Length; i++)
            {
                ModlesGlass[i].SetActive(false);
                if (ModlesGlass[i].tag == tag)
                {
                    ModlesGlass[i].SetActive(true);
                    modleGlass[3] = ModlesGlass[i];
                    animations[5] = ModlesGlass[i].GetComponent<Animation>();
                }
            }
            for (int i = 0; i < GlassStayles.Length; i++)
            {
                GlassStayles[i].SetActive(false);
                if (GlassStayles[i].tag==tag)
                {
                    GlassStayles[i].SetActive(true);
                    modleGlass[7] = GlassStayles[i];
                    modleGlass[7].SetActive(false);
                }
            }
        }
        public void ModleInit()
        {
            print(mAnimatorFSMModel.Mold_Style);
            switch (mAnimatorFSMModel.Mold_Style)
            {
                case AnimatorFSMModel.MoldStyle.Rule:
                    SetGlassStyle("Rule");
                    break;
                case AnimatorFSMModel.MoldStyle.Irregular:
                    SetGlassStyle("Irregular");
                    break;
                case AnimatorFSMModel.MoldStyle.Powder:
                    SetGlassStyle("Powder");
                    break;
                case AnimatorFSMModel.MoldStyle.Default:
                    break;
                default:
                    break;
            }
            print(camerasVirtual);
            camerasVirtual[0].Priority = 11;
        }
        public void CameraVitureInit()
        {
            camerasVirtual[1].Priority = 10;
        }
        public GameObject[] modleGlass;
        private void ActionKitEvent(int index, Animation ani, string aniStr, int nextIndex, string infor)
        {
            modleGlass[index].GetComponent<HighlightEffect>().highlighted = false;
            ani = modleGlass[index].GetComponent<Animation>();
            ActionKit.Sequence().Callback(() =>
            {
                ani[aniStr].time = ani[aniStr].clip.length;
                ani[aniStr].speed = -1;
                ani.Play(aniStr);
                ani.playAutomatically = true;
            }).
            Condition(() =>
            !ani.isPlaying
            ).
            Callback(() =>
            {
                ani.Stop();
                ani.playAutomatically = false;
                ani[aniStr].speed = 1;
                modleGlass[index].GetComponent<MeshCollider>().enabled = false;
                UIKit.GetPanel<MainExperimentPanel>().Infortxt(infor);
                modleGlass[nextIndex].GetComponent<HighlightEffect>().highlighted = true;
                switch (mAnimatorFSMModel.Mold_Style)
                {
                    case AnimatorFSMModel.MoldStyle.Rule:
                        UIKit.GetPanel<MainExperimentPanel>().SelectGlass.GetComponent<UIView>().SetVisibility(true);
                        break;
                    case AnimatorFSMModel.MoldStyle.Irregular:
                        UIKit.GetPanel<MainExperimentPanel>().SelectGlass.GetComponent<UIView>().SetVisibility(true);
                        break;
                    case AnimatorFSMModel.MoldStyle.Powder:
                        UIKit.GetPanel<MainExperimentPanel>().SelectGlassNoNumber.GetComponent<UIView>().SetVisibility(true);
                        break;
                    case AnimatorFSMModel.MoldStyle.Default:
                        break;
                    default:
                        break;
                }

                this.SendCommand<IccresseAniCommand>();


            }).Start(this);
        }
        private void ActionkitEvent(int index,int indexModle,string aniStr,string infor)
        {
            ActionKit.Sequence().Callback(() =>
            {
                modleGlass[indexModle].GetComponent<HighlightEffect>().highlighted = false;
                camerasVirtual[1].Priority = 11;
            }).Delay(seconds: 2f)
                     .Callback(() =>
                     {
                         print("可以播放动画了");
                         animations[index].playAutomatically = true;
                         animations[index].Play(aniStr);

                     }).
                     Condition(() =>
                        !animations[index].isPlaying
                     ).
                     Callback(() =>
                     {
                         print("动画结束");
                         animations[index].playAutomatically = false;
                         animations[index].Stop();
                         this.SendCommand<IbcreaseAniCommand>();
                         UIKit.GetPanel<MainExperimentPanel>().Infortxt(infor);


                     }).
                     Start(this, () =>
                     {

                     });
        
        }
        private void ActionKitEvent(string aniName, string infor, int index, int nextIndex, Animation animation)
        {
            ActionKit.Sequence().Callback(() =>
            {
                modleGlass[index].GetComponent<HighlightEffect>().highlighted = false;
                modleGlass[index].GetComponent<MeshCollider>().enabled = false;
                camerasVirtual[1].Priority = 11;
            }).Delay(seconds: 2f)
                        .Callback(() =>
                        {
                            print("可以播放动画了");
                            animation.playAutomatically = true;
                            animation.Play(aniName);

                        }).
                        Condition(() =>
                           !animation.isPlaying
                        ).
                        Callback(() =>
                        {
                            print("动画结束");
                            animation.playAutomatically = false;
                            animation.Stop();
                            UIKit.GetPanel<MainExperimentPanel>().Infortxt(infor);
                            modleGlass[nextIndex].GetComponent<HighlightEffect>().highlighted = true;
                            modleGlass[nextIndex].GetComponent<MeshCollider>().enabled = true;
                            if (index >= 0 && index < 3)
                            {
                                camerasVirtual[1].Priority = 0;
                            }

                        }).
                        Start(this);
        }
        private void ActionKitEvent(string aniName, int index, Animation animation, Animation animation1, string aninextName, int nextIndex, string infor, Animation animation2)
        {
            ActionKit.Sequence().Callback(() =>
            {
                modleGlass[index].GetComponent<HighlightEffect>().highlighted = false;
                modleGlass[index].GetComponent<MeshCollider>().enabled = false;
                camerasVirtual[1].Priority = 11;
            }).Delay(seconds: 3.2f)
                        .Callback(() =>
                        {
                            print("可以播放动画了");
                            animation.playAutomatically = true;
                            animation.Play(aniName);

                        }).
                        Condition(() =>
                           !animation.isPlaying
                        ).
                        Callback(() =>
                        {
                            print("动画结束");
                            animation.playAutomatically = false;
                            animation.Stop();
                            animation1.playAutomatically = true;
                            animation1.Play(aninextName);
                        }).
                         Condition(() =>
                           !animation1.isPlaying
                        ).
                        Callback(() =>
                        {
                            animation1.playAutomatically = false;
                            animation1.Stop();
                            animation2.playAutomatically = true;
                            animation2.Play();

                        }).
                        Condition(() =>
                         !animation2.isPlaying
                        ).
                        Callback(() =>
                        {
                            modleGlass[nextIndex].GetComponent<HighlightEffect>().highlighted = true;
                            modleGlass[nextIndex].GetComponent<MeshCollider>().enabled = true;
                            UIKit.GetPanel<MainExperimentPanel>().Infortxt(infor);
                            camerasVirtual[1].Priority = 0;
                        }).
                        Start(this);
        }
        private void StepMainExperiment()
        {
            mAnimatorFSMModel.FSM.State(AnimatorFSMModel.StepIstate.A)
           .OnEnter(() =>
           {
               Debug.Log(mAnimatorFSMModel.FSM.CurrentStateId + "Enter A");
               modleGlass[0].GetComponent<HighlightEffect>().highlighted = true;
               modleGlass[0].GetComponent<MeshCollider>().enabled = true;

           })
           .OnUpdate(() =>
           {
               Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
               //声明一个Ray结构体，用于存储该射线的发射点，方向
               RaycastHit hitInfo;
               if (Input.GetMouseButtonDown(0))
               {
                   //声明一个RaycastHit结构体，存储碰撞信息
                   if (Physics.Raycast(ray, out hitInfo))
                   {

                       if (hitInfo.collider.gameObject.name == "NaiHuoZhuan")
                       {
                           ActionKitEvent("MenShuang", 0, animations[0], animations[1], "LaMen", 1, "点击另一块耐火砖", animations[2]);
                       }
                       if (hitInfo.collider.gameObject.name == "NaiHuoZhuan1")
                       {
                           ActionKitEvent("NaiHuoZhuan1", "点击硼板", 1, 2, animations[3]);
                       }
                       else if (hitInfo.collider.gameObject.name == "PengBan")
                       {
                           ActionKitEvent("PenBan", "点击硼板", 2, 3, animations[4]);
                       }
                       else if (hitInfo.collider.gameObject.name == "ShiGaoMuJu_BuGuiZe")
                       {
                           ActionKitEvent("BuGuiZeMoJu", "点击窑炉门，关闭窑炉门", 3, 4, animations[5]);
                       }
                       else if (hitInfo.collider.gameObject.name == "ShiGaoMuJu_GuiZe")
                       {
                           ActionKitEvent("GuiZe", "点击窑炉门，关闭窑炉门", 3, 4, animations[5]);
                       }
                       else if (hitInfo.collider.gameObject.name == "ShiGaoMuJu_FenMo")
                       {
                           ActionKitEvent("FenMoMoJu", "点击窑炉门，关闭窑炉门", 3, 4, animations[5]);
                       }
                       else if (hitInfo.collider.gameObject.name == "YaoLu_LaMen_Small2")
                       {
                           modleGlass[4].GetComponent<HighlightEffect>().highlighted = false;
                           Animation ani = modleGlass[4].GetComponent<Animation>();
                           ActionKit.Sequence().Callback(() =>
                           {
                               ani["LaMen"].time = ani["LaMen"].clip.length;
                               ani["LaMen"].speed = -1;
                               ani.Play("LaMen");
                               ani.playAutomatically = true;
                           }).
                           Condition(() =>
                           !ani.isPlaying
                           ).
                           Callback(() =>
                           {
                               ani.Stop();
                               ani.playAutomatically = false;
                               ani["LaMen"].speed = 1;
                               modleGlass[4].GetComponent<MeshCollider>().enabled = false;
                               UIKit.GetPanel<MainExperimentPanel>().Infortxt("点击通气孔，打开");
                               modleGlass[5].GetComponent<HighlightEffect>().highlighted = true;
                               modleGlass[5].GetComponent<MeshCollider>().enabled = true;


                           }).Start(this);

                       }
                       else if (hitInfo.collider.gameObject.name == "YaoLu_TongQiKong_Small2")
                       {
                           ActionkitEvent(6,5, "TongQiKong", "点击窑炉设置面板");
                       }
                          
                   }

               }
           })
           .OnFixedUpdate(() =>
           {

           })
           .OnGUI(() =>
           {

           })
           .OnExit(() =>
           {
               print(mAnimatorFSMModel.FSM.CurrentStateId + "Exit A");
           });
            mAnimatorFSMModel.FSM.State(AnimatorFSMModel.StepIstate.B)
           .OnEnter(() =>
           {
               Debug.Log(mAnimatorFSMModel.FSM.CurrentStateId + "Enter B");
               modleGlass[6].GetComponent<HighlightEffect>().highlighted = true;
               modleGlass[6].GetComponent<MeshCollider>().enabled = true;

           })
           .OnUpdate(() =>
           {
               Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
               //声明一个Ray结构体，用于存储该射线的发射点，方向
               RaycastHit hitInfo;
               if (Input.GetMouseButtonDown(0))
               {
                   //声明一个RaycastHit结构体，存储碰撞信息
                   if (Physics.Raycast(ray, out hitInfo))
                   {
                       if (hitInfo.collider.gameObject.name == "YaoLu_DianKongXiang_WaiKe1")
                       {
                           ActionKit.Sequence()
                           .Callback(() =>
                           {
                               UIKit.GetPanel<MainExperimentPanel>().TemperatureSetting.GetComponent<UIView>().SetVisibility(true);
                               hitInfo.collider.gameObject.GetComponent<HighlightEffect>().highlighted = false;
                             
                           }).Start(this);
                       }
                       else if (hitInfo.collider.gameObject.name == "YaoLu_LaMen_Small2")
                       {
                           ActionKitEvent("LaMen", "点击模具", 4, 3, animations[1]);
                           modleGlass[7].SetActive(true);
                       }
                       else if (hitInfo.collider.gameObject.name == "ShiGaoMuJu_BuGuiZe")
                       {
                           ActionKitEvent(3, animations[5], "BuGuiZeMoJu", 7, "根据模具选择步骤样式");
                    
                       }
                       else if (hitInfo.collider.gameObject.name == "ShiGaoMuJu_FenMo")
                       {
                           ActionKitEvent(3, animations[5], "FenMoMoJu", 7, "根据模具选择步骤样式");
                       
                       }
                       else if (hitInfo.collider.gameObject.name == "ShiGaoMuJu_GuiZe")
                       {
                           ActionKitEvent(3, animations[5], "GuiZe", 7, "根据模具选择步骤样式");
               
                       }
                   }
               }
           })
           .OnExit(() =>
           {

               print(mAnimatorFSMModel.FSM.CurrentStateId + "Exit B");
           });
            mAnimatorFSMModel.FSM.State(AnimatorFSMModel.StepIstate.C)
           .OnEnter(() =>
           {
               Debug.Log(mAnimatorFSMModel.FSM.CurrentStateId + "Enter C");
           })
           .OnUpdate(() =>
           {
               if (Input.GetKeyDown(KeyCode.D))
               {
                   this.SendCommand<IdcresseAniCommand>(); ;
               }
           })
           .OnExit(() =>
           {
               print(mAnimatorFSMModel.FSM.CurrentStateId + "Exit C");
           });
            mAnimatorFSMModel.FSM.State(AnimatorFSMModel.StepIstate.D)
           .OnEnter(() =>
           {
               Debug.Log(mAnimatorFSMModel.FSM.CurrentStateId + "Enter D");
           })
           .OnUpdate(() =>
           {
               if (Input.GetKeyDown(KeyCode.E))
               {
                   this.SendCommand<IecresseAniCommand>(); ;
               }
           })
           .OnExit(() =>
           {

               print(mAnimatorFSMModel.FSM.CurrentStateId + "Exit D");
           });
            mAnimatorFSMModel.FSM.State(AnimatorFSMModel.StepIstate.E)
           .OnEnter(() =>
           {
               Debug.Log(mAnimatorFSMModel.FSM.CurrentStateId + "Enter E");
           })
           .OnUpdate(() =>
           {
               if (Input.GetKeyDown(KeyCode.F))
               {
                   this.SendCommand<IfcresseAniCommand>(); ;
               }
           })
           .OnExit(() =>
           {
               print(mAnimatorFSMModel.FSM.CurrentStateId + "Exit E");
           });
            mAnimatorFSMModel.FSM.State(AnimatorFSMModel.StepIstate.F)
           .OnEnter(() =>
           {
               Debug.Log(mAnimatorFSMModel.FSM.CurrentStateId + "Enter F");
           })
           .OnUpdate(() =>
           {
               if (Input.GetKeyDown(KeyCode.G))
               {
                   this.SendCommand<IgcresseAniCommand>(); ;
               }
           })
           .OnExit(() =>
           {

               print(mAnimatorFSMModel.FSM.CurrentStateId + "Exit f");
           });
            mAnimatorFSMModel.FSM.StartState(AnimatorFSMModel.StepIstate.A);
        }

        // Update is called once per frame
        private void Update()
        {

            mAnimatorFSMModel.FSM.Update();
        }
        private void FixedUpdate()
        {

            mAnimatorFSMModel.FSM.FixedUpdate();
        }
        private void OnGUI()
        {

            mAnimatorFSMModel.FSM.OnGUI();
        }
        private void OnDestroy()
        {
            mAnimatorFSMModel.FSM.Clear();
            mAnimatorFSMModel = null;
        }
        public IArchitecture GetArchitecture()
        {
            return AnimatorApp.Interface;
        }
        public void OnSingletonInit()
        {

        }

    }

}