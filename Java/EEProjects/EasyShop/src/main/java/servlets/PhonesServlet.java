package servlets;
import models.Phone;

import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.ArrayList;

@WebServlet (name = "PhonesServlet", urlPatterns = "/phones")
public class PhonesServlet extends HttpServlet {
    static final ArrayList<Phone> LIST_PHONES = new ArrayList();
    
    protected void doGet(HttpServletRequest req, HttpServletResponse resp)
            throws ServletException, IOException {
        req.setAttribute("phones", LIST_PHONES);
        req.getRequestDispatcher("WEB-INF/views/phones.jsp").forward(req, resp);
    }
    
    @Override
    public void init(ServletConfig config) throws ServletException {
        super.init(config);
        
        LIST_PHONES.add(new Phone("Samsung", "Galaxy S9",
                                  "samsung_galaxy_s9_64gb_black_images_3249371727.jpg", 11.999));
        LIST_PHONES.add(new Phone("Nokia", "7.2",
                                  "nokia_7_2_4_64gb_silver_images_13891308811.jpg", 6.299));
        LIST_PHONES.add(new Phone("Blackview", "A60 Pro",
                                  "blackview_6931548305781_images_13936944982.jpg", 2.299));
        LIST_PHONES.add(new Phone("Huawei", "Y7",
                                  "huawei_y7_2019_blue_images_10606920410.jpg", 4.499));
        LIST_PHONES.add(new Phone("Tecno", "POP 2 Power",
                                  "copy_tecno_b1p_dual_gold_images_12852510276.jpg", 11.999));
    }
}
