using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Context/Conf/ChatData", fileName = "ChatDataContext", order = 2)]
public class UIConfChatData : ScriptableObject, IUIConfChatContext
{
    [SerializeField] private List <IUIConfChatContext.Chat> chatList;
    [SerializeField] private IUIConfChatContext.ChatType chatType;

    public List<IUIConfChatContext.Chat> ChatList => chatList;

    public IUIConfChatContext.ChatType ChatTypes => chatType;
    public void OnChatted()
    {
        
    }

    public void OnClickedChatType()
    {
       
    }

    public void OnClickedEmoticonButton()
    {
       
    }
}
