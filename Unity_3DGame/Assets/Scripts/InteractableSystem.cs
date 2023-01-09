
using UnityEngine;
using UnityEngine.Events;

namespace Nick
{
    /// <summary>
    /// ���ʨt��:�������a�O�_�i�JĲ�o�ϰ�óB�z���ʦ欰
    /// </summary>


    public class InteractableSystem : MonoBehaviour
    {
        [SerializeField, Header("�Ĥ@�q��ܸ��")]
        private DialogueData dataDialogue;
        [SerializeField, Header("��ܵ����᪺�ƥ�")]
        private UnityEvent onDialogueFinish;

        [SerializeField, Header("�ҰʹD��")]
        private GameObject propActive;
        [SerializeField, Header("�Ұʫ᪺��ܸ��")]
        private DialogueData dataDialogueActive;
        [SerializeField, Header("�Ұʫ��ܵ����᪺�ƥ�")]
        private UnityEvent onDialogueFinishAfterActive;


        private string nameTarget = "PlayerCapsule";
        private DialogueSystem dialogueSystem;

        private void Awake()
        {
            dialogueSystem = GameObject.Find("�e����ܨt��").GetComponent<DialogueSystem>();
        }
        // ��ӸI������I��
        // �䤤�@�Ӧ��Ŀ� Is Trigger
        // Ĳ�o�}�l
        private void OnTriggerEnter(Collider other)
        {
            //�p�G �I������W�� �]�t PlayerCapsule �N����  { }
            if (other.name.Contains(nameTarget))
            {
                print(other.name);

                // �p�G ���ݭn�ҰʹD�� �Ϊ� �ҰʹD��O��ܪ��A(�٨S��) �N����Ĥ@�q���
                if (propActive == null || propActive.activeInHierarchy)
                {
                    dialogueSystem.StartDialogue(dataDialogue, onDialogueFinish);
                }
                else
                {
                    dialogueSystem.StartDialogue(dataDialogueActive,onDialogueFinishAfterActive);

                }

            }
        }

        // Ĳ�o���}
        private void OnTriggerExit(Collider other)
        {

        }

        // Ĳ�o����
        private void OnTriggerStay(Collider other)
        {

        }


        /// <summary>
        /// ���ê���
        /// </summary>
        public void HiddenObject()
        {
            gameObject.SetActive(false);
        }

    }
}