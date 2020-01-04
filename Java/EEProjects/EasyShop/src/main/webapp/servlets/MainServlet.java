package webapp.servlets;
import lombok.var;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

@WebServlet (urlPatterns = {"/", "/main" }, loadOnStartup = 1, displayName = "main", name = "MainServlet")
public class MainServlet extends HttpServlet {
    
    protected void doPost(HttpServletRequest req, HttpServletResponse res)
            throws ServletException, IOException {
        
        var stream = res.getWriter();
        res.setContentType("text/html; charset=UTF-8");
        
        getServletContext().getRequestDispatcher("/views/index.jsp").include(req, res);
    }
    
    protected void doGet(HttpServletRequest req, HttpServletResponse res)
            throws ServletException, IOException {
        
    }
    
}
