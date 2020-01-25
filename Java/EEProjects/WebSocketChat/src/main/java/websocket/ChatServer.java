package websocket;
import org.apache.log4j.Logger;
import javax.websocket.CloseReason;
import javax.websocket.OnClose;
import javax.websocket.OnError;
import javax.websocket.OnMessage;
import javax.websocket.OnOpen;
import javax.websocket.Session;
import javax.websocket.server.ServerEndpoint;
import java.io.IOException;
import java.util.HashMap;

@ServerEndpoint("/chat")
public class ChatServer {
    private static final Logger LOG = Logger.getLogger(ChatServer.class);
    private static final HashMap<String, String> users = new HashMap<>();
    
    @OnOpen
    public void onOpen(Session session) throws IOException{
        LOG.debug("onOpen");
    }
    
    @OnMessage
    public void onMessage(Session session, String message) throws IOException{
        LOG.debug("onMessage");
    }
    
    @OnError
    public void onError(Session session, Throwable throwable) throws IOException{
        LOG.debug("onError");
    }
    
    @OnClose
    public void onClose(Session session, CloseReason closeReason) throws IOException{
        LOG.debug("onClose");
    }
}
