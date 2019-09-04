<?php

namespace app\controllers;

use Yii;
use app\models\Positions;
use app\models\Commands;
use app\models\Players;
use app\Models\PlayersSearch;
use yii\web\Controller;
use yii\web\NotFoundHttpException;
use yii\filters\VerbFilter;
use yii\helpers\ArrayHelper;
//use yii\data\ActiveDataProvider;
use yii\filters\AccessControl;
use \yii\web\HttpException;


class PlayersController extends Controller
{
    private function  getCommands() :Array{
        $commands = Commands::find()->all();
        $commands = ArrayHelper::map($commands, 'id', 'name');
        array_unshift($commands, '');

        return $commands;
    }

    private function getPositions() :Array{
        $positions = Positions::find()->all();
        $positions = ArrayHelper::map($positions, 'id', 'name');
        array_unshift($positions, '');

        return $positions;
    }

    public function behaviors()
    {
        return [
            'access' => [
                'class' => AccessControl::className(),
                'denyCallback' => function () {
                    throw new HttpException(403,'Авторизируйтесь, чтобы вносить изменения.');
                    },
                'only' => ['create', 'update', 'delete', 'view', 'index'],
                'rules' => [
                    [
                        'allow' => true,
                        'actions' => ['view', 'index'],
                        'roles' => ['?'],
                    ],
                    [
                        'allow' => true,
                        'actions' => ['view', 'index', 'create', 'update', 'delete'],
                        'roles' => ['@'],
                    ],
                ]
            ],
            'verbs' => [
                'class' => VerbFilter::className(),
                'actions' => [
                    'delete' => ['POST'],
                ],
            ],
        ];
    }

    public function actionIndex()
    {
        $searchModel = new PlayersSearch();
        $dataProvider = $searchModel->search(Yii::$app->request->queryParams);

        return $this->render('index', [
            'searchModel' => $searchModel,
            'dataProvider' => $dataProvider
        ]);
    }

    public function actionView($id)
    {
        return $this->render('view', [
            'model' => $this->findModel($id),
        ]);
    }

    public function actionCreate()
    {
        $model = new Players();

        if ($model->load(Yii::$app->request->post())){
            if ($_FILES and $_FILES['Players']['error']['photo_filename'] == 0){
                $tmp_name = $_FILES['Players']['tmp_name']['photo_filename'];
                $file_ext = pathinfo($_FILES['Players']['name']['photo_filename'], PATHINFO_EXTENSION);
                $filename = uniqid() . '.' . $file_ext;
                rename($tmp_name, Players::PHOTOS_DIR . $filename);
                $model->photo_filename = $filename;
            }

            $model->save();
//            if($model->save()){
//                //Добавление игрока в состав
//                $lineUp = new LineUps();
//                $lineUp->command_id = $_POST['command_id'];
//                $lineUp->player_id = $model->id;
//                $lineUp->year = date('Y');
//                $lineUp->save();
                
                return $this->redirect(['index']);
//            }
        }
        
        return $this->render('create', [
            'model' => $model,
            'positions' => $this->getPositions(),
            'commands' => $this->getCommands()
        ]);
    }

    public function actionUpdate($id)
    {
        $model = $this->findModel($id);

        if ($model->load(Yii::$app->request->post())){
            if ($_FILES and $_FILES['Players']['error']['photo_filename'] == 0){
                $tmp_name = $_FILES['Players']['tmp_name']['photo_filename'];
                $file_ext = pathinfo($_FILES['Players']['name']['photo_filename'], PATHINFO_EXTENSION);
                $filename = uniqid() . '.' . $file_ext;
                rename($tmp_name, Players::PHOTOS_DIR . $filename);
                $model->photo_filename = $filename;
            }
            else{
                $model->photo_filename = Players::find($id)->one()->photo_filename;
            }

            $model->save();

            return $this->redirect(['index']);
        }

        return $this->render('update', [
            'model' => $model,
            'positions' => $this->getPositions(),
            'commands' => $this->getCommands()
        ]);
    }

    public function actionDelete($id)
    {
        $model = $this->findModel($id);
        $model->isDelete = 1;
        $model->save();
        
        return $this->redirect(['index']);
    }

    protected function findModel($id)
    {
        if (($model = Players::findOne($id)) !== null) {
            return $model;
        }

        throw new NotFoundHttpException('The requested page does not exist.');
    }
}
