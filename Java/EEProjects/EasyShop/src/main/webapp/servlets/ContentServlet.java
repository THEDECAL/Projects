/*******************************************************************************
 * Development by THE DECAL! (2020)
 ******************************************************************************/

package webapp.servlets;
import lombok.var;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet (urlPatterns = {"/", "/main", "/index" }, loadOnStartup = 1, displayName = "main", name = "MainServlet")
public class ContentServlet extends HttpServlet {
    
    protected void doGet(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {
        
        var stream = resp.getWriter();
        resp.setContentType("text/html; charset=UTF-8");
        
        getServletContext().getRequestDispatcher("/views/index.jsp").include(req, resp);
    }
    
    protected void doPost(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {
        
    }
    
    @Override
    protected void doHead(javax.servlet.http.HttpServletRequest req, javax.servlet.http.HttpServletResponse resp) throws javax.servlet.ServletException, java.io.IOException{
        super.doHead(req, resp);
    }
    
}
