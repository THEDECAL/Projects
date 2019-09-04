<?php

namespace app\controllers;

use app\models\phones\Phone;
use app\models\phones\PhonesDao;
use yii;
use yii\web\Controller;

class PhonesController extends Controller
{
    private $phonesDao;
    public function __construct($id, $module, $config = []){
        parent::__construct($id, $module, $config);
        $this->phonesDao = PhonesDao::getInstance();
    }
    public function actionIndex()
    {
        $phones = $this->phonesDao->getAll();
        return $this->render('index', ['phones' => $phones]);
    }
    public function actionEdit($id){
        $phone = $this->phonesDao->get($id);
        if(Yii::$app->request->isPost){
            $filename = '';
            extract($_POST);
            if ($_FILES and $_FILES['file']['error'] == 0){
                $dir_images = '../views/phones/images/';
                $tmp_name = $_FILES['file']['tmp_name'];
                $file_ext = pathinfo($_FILES['file']['name'], PATHINFO_EXTENSION);
                $filename = uniqid() . '.' . $file_ext;
                rename($tmp_name, $dir_images . $filename);
            }
            else{
                $filename = $phone->getImageFileName();
            }
            $phone = new Phone(
                $id,
                $brand,
                $model,
                $price,
                $filename
            );
            $this->phonesDao->update($phone);
            return Yii::$app->response->redirect(['/phones/index']);
        }
        return $this->render('addedit', ['phone' => $phone]);
    }
    public function actionAdd(){
        if(Yii::$app->request->isPost){
            $filename = '';
            extract($_POST);
            if ($_FILES and $_FILES['file']['error'] == 0){
                $dir_images = '../views/phones/images/';
                $tmp_name = $_FILES['file']['tmp_name'];
                $file_ext = pathinfo($_FILES['file']['name'], PATHINFO_EXTENSION);
                $filename = uniqid() . '.' . $file_ext;
                rename($tmp_name, $dir_images . $filename);
            }
            $phone = new Phone(
                '',
                $brand,
                $model,
                $price,
                $filename
            );
            $this->phonesDao->save($phone);
            return Yii::$app->response->redirect(['/phones/index']);
        }
        return $this->render('addedit');
    }
    public function actionDelete($id){
    	$this->phonesDao->delete($id);
    	return $this->redirect(['/phones/index']);
    }
}
