package websocket;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import lombok.var;
import models.Message;
import org.apache.log4j.Logger;

import javax.websocket.*;
import javax.websocket.server.ServerEndpoint;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Set;

@ServerEndpoint("/chat")
public class ChatServer {
    private static final Logger LOG = Logger.getLogger(ChatServer.class);
    private static final HashMap<String, String> USERS = new HashMap<>();
    private static final Gson GSON = new Gson();
    
    @OnOpen
    public void open(Session session) throws IOException{
        LOG.debug("session " + session.getId() + " openned");
    }
    
    @OnMessage
    public void message(Session session, String jsonMessage)
            throws IOException{
        Message receivedMsg = GSON.fromJson(jsonMessage, Message.class);
        Message msgToSend = null;

        if(receivedMsg != null){
            switch (receivedMsg.getType()) {
                case "conn":
                    USERS.put(session.getId(), receivedMsg.getData());
                    var jsonUsers = GSON.toJson(USERS);
                    msgToSend = new Message(Message.Type.USER_ADD,
                            null, jsonUsers, null);

                    sendBroadcastMessage(session.getOpenSessions(), msgToSend);
                    LOG.debug("user \"" + receivedMsg.getData() + "\" entered");
                    break;
                case "msg":
                    msgToSend = new Message(Message.Type.MSG,
                            getUserNameBySessionId(session.getId()),
                            receivedMsg.getData(),
                            receivedMsg.getDate());

                    sendBroadcastMessage(session.getOpenSessions(), msgToSend);
                    break;
                default:
                    throw new IllegalStateException("Unexpected value: " + receivedMsg.getType());
            }
        }
    }
    
    @OnError
    public void error(Session session, Throwable throwable)
            throws IOException{
        LOG.debug("session " + session.getId() + " error");
    }
    
    @OnClose
    public void close(Session session, CloseReason closeReason)
            throws IOException{
        LOG.debug("user \"" + getUserNameBySessionId(session.getId()) + "\" exited");
        LOG.debug("session " + session.getId() + " closed");
        USERS.remove(session.getId());
    }

    private String getUserNameBySessionId(String id){
        return USERS.getOrDefault(id, null);
    }

    private void sendBroadcastMessage(Set<Session> sessions, Message msg){
        var jsonMsg = GSON.toJson(msg);

        sessions.stream().forEach((s) -> {
            try {
                s.getBasicRemote().sendText(jsonMsg);
                s.getBasicRemote().sendObject(jsonMsg);
            }
            catch (IOException e) { e.printStackTrace(); }
            catch (EncodeException e) { e.printStackTrace(); }
        });
    }
}
