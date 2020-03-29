package localhost.controllers;

import localhost.models.Account;
import localhost.models.AccountReginModel;
import localhost.models.Task;
import localhost.repositories.AccountRepository;
import localhost.repositories.TaskRepository;
import lombok.var;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;

import java.util.HashSet;
import java.util.Map;
import java.util.Set;

@Controller
public class MainController {
    @Autowired
    AccountRepository accountRepository;
    @Autowired
    TaskRepository taskRepository;

    private Authentication getAuth(){
        return SecurityContextHolder.getContext().getAuthentication();
    }

    @GetMapping(path = {"/", "/index"})
    public String index(Map<String, Object> model){
        model.put("login", getAuth().getName());
        model.put("tasks", taskRepository.findAll());

        return "index";
    }

    @GetMapping(path = "/active-remove")
    public String activeRemove(Long activeId, Long removeId){
        if(activeId != null){
            try{
                var findTask = taskRepository.findById(activeId).get();
                findTask.setIsActive(!findTask.getIsActive());
                taskRepository.save(findTask);
            } catch(Exception ex){}
        }
        else if(removeId != null){
            taskRepository.deleteById(removeId);
        }

        return "redirect:/index";
    }

    @GetMapping(path = "/login")
    public String login(Map<String, Object> model){
        model.put("login", getAuth().getName());
        return "login";
    }

    @GetMapping(path = "/logout")
    public String logout(){
        getAuth().setAuthenticated(false);
        return "redirect:/index";
    }

    @GetMapping(path = "/regin")
    public String regin(Map<String, Object> model){
        model.put("login", getAuth().getName());
        return "regin";
    }

    @PostMapping(path = "/regin")
    public String regin(AccountReginModel account, Map<String, Object> model) {
        Account accExist = accountRepository.findByLogin(account.getLogin());

        if(accExist == null){
            Set<Account.Role> set = new HashSet<Account.Role>();
            set.add(Account.Role.USER);
            var newAccount = new Account(null, account.getLogin(), account.getPassword1(), true, set);

            accountRepository.save(newAccount);
        }
        else { return "redirect:/error"; }

        return "redirect:/login";
    }

    @GetMapping(path = "/add-edit")
    public String addEdit(Long id, Map<String, Object> model) {
        var task = new Task();

        if(id != null){
            try {
                var findTask = taskRepository.findById(id);
                task = findTask.get();
                model.put("mode", "edit");
            }
            catch(Exception ex){ model.put("mode", "add"); }
        }
        else{ model.put("mode", "add"); }

        model.put("login", getAuth().getName());
        model.put("task", task);

        return "add-edit";
    }

    @PostMapping(path = "/add-edit")
    public String addEdit(Task task, Map<String, Object> model) {
        var findAccount = accountRepository.findByLogin(getAuth().getName());
        if(findAccount != null) { task.setOwner(findAccount); }
        taskRepository.save(task);

        return "redirect:/index";
    }
}