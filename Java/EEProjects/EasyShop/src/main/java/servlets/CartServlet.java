package servlets;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import models.Phone;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;

@WebServlet (name = "CartServlet", urlPatterns = "/cart")
public class CartServlet extends HttpServlet {
    
    /** Получение списка телефонов из куки корзины */
    static public ArrayList<Phone> getPhonesList(HttpServletRequest request){
        final String phonesCookieName = "phones";
        var cookies = Arrays.asList(request.getCookies());
        var phonesInCartCookie = cookies.stream().filter(c -> phonesCookieName.equals(c.getName())).findFirst().orElse(null);
        
        if (phonesInCartCookie != null) {
            var listType = new TypeToken<ArrayList<Phone>>() {}.getType();
            return new Gson().fromJson(phonesInCartCookie.getValue(), listType);
        }
        
        return new ArrayList<Phone>();
    }
    //Получение куки телефонов из списка телефонов */
    static public Cookie getPhonesCookie(List<Phone> listPhones){
        var phonesListJson = new Gson().toJson(listPhones);
        var phonesCookie = new Cookie("phones", phonesListJson);
        phonesCookie.setMaxAge(-1);
        
        return phonesCookie;
    }
    
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException{
        var id = request.getParameter("id");
        var delId = request.getParameter("delId");
        var phoneList = getPhonesList(request);
        
        if (id == null && delId == null) {
            request.setAttribute("phones", getPhonesList(request));
            request.getRequestDispatcher("WEB-INF/views/cart.jsp").forward(request, response);
        }
        
        if (id != null && delId == null) {
            try {
                //Поиск телефона в списке
                final var phoneId = Integer.parseInt(id);
                final var phone = PhonesServlet.LIST_PHONES.get(phoneId);
                phoneList.add(phone);
                
                //Добавление телефонов в куки корзину
                var phonesCookie = getPhonesCookie(phoneList);
                response.addCookie(phonesCookie);
            }
            catch (NumberFormatException ex) {}
            catch (IndexOutOfBoundsException ex) {}
            finally {
                var path = request.getContextPath() + "/phones";
                response.sendRedirect(path);
            }
        }
        else if (delId != null && id == null) {
            try {
                final var phoneDelId = Integer.parseInt(delId);
                phoneList.get(phoneDelId);
                phoneList.remove(phoneDelId);
                
                var phonesCookie = getPhonesCookie(phoneList);
                response.addCookie(phonesCookie);
            }
            catch (NumberFormatException ex) {}
            catch (IndexOutOfBoundsException ex) {}
            finally {
                var path = request.getContextPath() + "/cart";
                response.sendRedirect(path);
            }
        }
    }
}
