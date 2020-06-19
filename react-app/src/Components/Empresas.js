import React, { useState, useEffect } from 'react';
import { connect } from 'react-redux';
import * as actions from '../Actions/empresa';
import Axios from "axios";
import {
    Grid, Paper, TableContainer, Table, TableHead,
    TableRow, TableCell, TableBody, withStyles, Button, Select, MenuItem, InputLabel
} from '@material-ui/core';

import { Conteudo } from '../styles';

import Upload from './Upload';
import Snackbar from '@material-ui/core/Snackbar';
import Alert from '@material-ui/lab/Alert'

const FileDownload = require('js-file-download');



const escreverTodos = () => {
    Axios.get(`http://localhost:59044/api/empresas/escreverTodos/`)
        .then((response) => {
            FileDownload(response.data, 'Dados_Empresas.txt');
        });
};

const styles = theme => ({

    root: {
        "& .MuiTableCell-head": {
            fontSize: "0.95rem"
        }
    },
    paper: {
        margin: theme.spacing(2),
        padding: theme.spacing(2)
    },
    snackBar: {
        width: '100%',
        '& > * + *': {
            marginTop: theme.spacing(2),
        },
    },
})

const Empresas = ({ classes, ...props }) => {


    const [selectedEmpresa, setSelectedEmpresa] = useState([]);
    const [uploadedFile, setUploadedFile] = useState([]);
    const [mensagemErro, setMensagemErro] = useState({});
    const [open, setOpen] = useState(false);
    const [severity, setSeverity] = useState({});

    const handleChange = (event) => {
        setSelectedEmpresa(event.target.value);
    };

    const handleClose = (event, reason) => {
        if (reason === 'clickaway') {
            return;
        }

        setOpen(false);
    };

    const processUpload = (arquivo) => {
        setUploadedFile(arquivo);
        const data = new FormData();

        data.append('file', arquivo[0]);

        Axios.post(`http://localhost:59044/api/empresas/enviarArquivo/${selectedEmpresa}`, data, {
        })
            .then(() => {
                props.fetchAllEmpresas();
                setMensagemErro("Upload feito com sucesso.");
                setSeverity("success");
            })
            .catch(err => {
                if (err.response.status === 500) {
                    setMensagemErro("Impossível ler o Arquivo.");
                    setSeverity("error");
                }
                if (err.response.state === 400) {
                    setMensagemErro("Arquivo precisa ser do tipo texto. (.txt)");
                    setSeverity("error");
                }
            })
            .then(() => {
                setOpen(true);
            })
    }

    useEffect(() => {
        props.fetchAllEmpresas()
    }, []
    )

    return (
        <div>
            <Paper elevation={3}>
                <div className={classes.snackBar}>
                    <Snackbar open={open} autoHideDuration={3000} onClose={handleClose}>
                            <Alert onClose={handleClose} severity={severity}>
                                {mensagemErro}
                            </Alert>
                    </Snackbar>
                </div>
                <Grid container>
                    <Grid item xs={12}>
                        <h1>Ranking de Empresas</h1>
                        <TableContainer>
                            <Table>
                                <TableHead className={classes.root}>
                                    <TableRow>
                                        <TableCell>Pontuação</TableCell>
                                        <TableCell>Codigo</TableCell>
                                        <TableCell>Nome</TableCell>
                                        <TableCell>Notas Fiscais neste mes</TableCell>
                                        <TableCell>Debitos neste mes</TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {
                                        props.listaEmpresas.map((record, index) => {
                                            return (<TableRow key={index} hover>
                                                <TableCell>{record.rating}</TableCell>
                                                <TableCell>{record.id}</TableCell>
                                                <TableCell>{record.nome}</TableCell>
                                                <TableCell>{record.notasEsteMes}</TableCell>
                                                <TableCell>{record.debitosEsteMes}</TableCell>
                                            </TableRow>)
                                        })
                                    }
                                </TableBody>
                            </Table>
                        </TableContainer>
                        <Button style={{ marginTop: '5px', marginLeft: '5px' }}
                            variant="contained"
                            color="primary"
                            onClick={escreverTodos}>Baixar Todos</Button>
                    </Grid>
                </Grid>
                <div style={{ marginTop: '5px', marginLeft: '5px' }}>
                    <InputLabel id="demo-mutiple-name-label">Selecione a Empresas para upload</InputLabel>
                    <Select
                        labelId="demo-mutiple-name-label"
                        onChange={(e) => {
                            handleChange(e);
                        }}
                    >
                        {props.listaEmpresas.map((empresa, index) => (
                            <MenuItem key={index} value={empresa.id}>
                                {empresa.nome}
                            </MenuItem>
                        ))}
                    </Select>
                    <Conteudo>
                        <p>Upload do Arquivo Seed</p>
                        <Upload onUpload={processUpload} />
                    </Conteudo>
                </div>
            </Paper>
        </div>
    );
}

const mapStateProps = state => ({
    listaEmpresas: state.empresa.list,
    uploadedFile: {}
})

const mapActionToProps = {
    fetchAllEmpresas: actions.fetchAll,
}

export default connect(mapStateProps, mapActionToProps)(withStyles(styles)(Empresas));
