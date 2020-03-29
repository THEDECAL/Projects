package localhost.controllers;

import localhost.models.Account;
import localhost.models.Photo;
import localhost.repositories.PhotoRepository;
import lombok.var;
import org.apache.commons.io.FilenameUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.security.core.annotation.AuthenticationPrincipal;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import java.io.File;
import java.io.IOException;
import java.time.LocalDate;
import java.util.UUID;

@Controller
public class PhotoController {
    @Autowired
    private PhotoRepository photoRepo;
    @Value("${upload-relative-path}")
    private String uploadRelativePath;

    @GetMapping(path = {"/", "/index"})
    public String index(Boolean myPhoto, @AuthenticationPrincipal Account acc, Model model){
        var photos = (myPhoto != null && acc != null)
                ? photoRepo.findPhotosByOwner(acc)
                : photoRepo.findAll();
        model.addAttribute("photos", photos);
        return "index";
    }
    @GetMapping(path = "/remove")
    public String activeRemove(@RequestParam("id") Photo photo,
                               @AuthenticationPrincipal Account acc,
                               RedirectAttributes redirectAtt){
        if(photo != null && acc != null) {
            if(photo.getOwner().getId().equals(acc.getId()))
                photoRepo.delete(photo);
            else{
                redirectAtt.addFlashAttribute("error_text", "Вы не владелец данной картинки.");
                return "redirect:/error";
            }
        }
        return "redirect:/index";
    }
    @GetMapping(path = "/add")
    public String add() { return "add-edit"; }
    @GetMapping(path = "/edit")
    public String edit(@RequestParam("id") Photo photo,
                       @AuthenticationPrincipal Account acc,
                       RedirectAttributes redirectAtt, Model model) {
        if(photo != null && acc != null) {
            if(photo.getOwner().getId().equals(acc.getId()))
                model.addAttribute("photo", photo);
            else{
                redirectAtt.addFlashAttribute("error_text", "Вы не владелец данной картинки.");
                return "redirect:/error";
            }
        }

        return "add-edit";
    }
    @PostMapping(path = {"/edit", "/add"})
    public String addEdit(Photo photo,
                          @AuthenticationPrincipal Account acc,
                          @RequestParam("file") MultipartFile file,
                          RedirectAttributes redirectAtt)
            throws IOException
    {
        if(acc != null && photo != null){
            var fileUuid = UUID.randomUUID().toString();
            var fileExt = FilenameUtils.getExtension(file.getOriginalFilename());
            var fileName = fileUuid + '.' + fileExt;
            var workingDir = System.getProperty("user.dir");
            if(!file.isEmpty()) {
                file.transferTo(new File(workingDir + '/' + uploadRelativePath + '/' + fileName));
                photo.setImgName(fileName);
            }
            else{
                try{
                    var findPhoto = photoRepo.findById(photo.getId());
                    photo.setImgName(findPhoto.get().getImgName());
                }
                catch(Exception ex){
                    redirectAtt.addFlashAttribute("error_text", "Файл обязательно нужно выбрать.");
                    return "redirect:/error";
                }
            }

            photo.setOwner(acc);
            photo.setAddedDate(LocalDate.now());

            photoRepo.save(photo);
        }
        else return "redirect:/error";

        return "redirect:/index";
    }
}