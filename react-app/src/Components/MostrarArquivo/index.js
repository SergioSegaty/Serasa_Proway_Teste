import React from 'react';
import { Container, FileInfo } from './styles';
import { CircularProgressbar } from 'react-circular-progressbar';
import { MdCheckCircle, MdError } from 'react-icons/md';



const MostrarArquivo = (uploadedfile) => (
    
    <Container>
        {(uploadedFile => (
            <li key={"id"}>
                <FileInfo>
                    <div>
                        <strong>{uploadedFile.name}</strong>
                        <span>{uploadedFile.readableSize} <button onClick={() => { }}>Excluir</button></span>
                    </div>
                </FileInfo>

                <div>
                    {!uploadedFile.uploaded && !uploadedFile.error && (
                        <CircularProgressbar
                            styles={{
                                root: { width: 24 },
                                path: { stroke: '#7159c1' }
                            }}
                            strokeWidth={10}
                            percentage={uploadedFile.progress}
                        />
                    )}
                    {uploadedFile.uploaded && <MdCheckCircle size={24} color="#78e5d5" />}
                    {uploadedFile.error && <MdError size={24} color="#e57878" />}
                </div>
            </li>
        ))}
    </Container>
);

export default MostrarArquivo;